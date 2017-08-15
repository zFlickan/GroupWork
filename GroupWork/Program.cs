using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Anders Björn
Frida Eriksson
Lena Fridlund
Johan Hagborg
Rebecca Leckborn
Andreas Johansson
Nikola Jovanovic
Daniel Rasmusson
Gustav Themer
Aron Törnqvist
*/
// Anders, Frida, Lena, Johan, Rebecca, Andreas, Niko, Daniel, Gustav, Aron

namespace GroupWork
{
	class Program
	{
		private static Random rng = new Random();

		public static void Main()
		{
            // TODO: Flytta fler saker till metoder

		    // TODO: GetListOfNames returnerar inte en lista. Namnet är missvisande	
			string allPersonsString = GetListOfNames();					//Läs in data från användaren till en string
			
			string[] allPersonsArray = allPersonsString.Split(',');		//Skapa en array från strängen
			
			ShuffleArray(allPersonsArray);								//Shuffle users
			
			int numberOfPeople = allPersonsArray.Length;				//Sätt värdet på numberOfPeople (antal deltagare) 

			int totalNumberOfGroupsPoss = numberOfPeople / 2;           //Ta reda på antalet möjliga grupper (alltså minst två pers per grupp)

			//Läs in data från användaren
			int numberOfGroups = GetNumberOfGroups(totalNumberOfGroupsPoss);
			
            // TODO: denna variabel är överflödig
			int numberOfPeoplePerGroup = numberOfPeople / numberOfGroups;		//Beräkna hur många medlemmar det blir per grupp

			int rest = numberOfPeople % numberOfGroups;							//Beräkna eventuellt restvärde

			//Set placeholders i arrayen (ifall antalet personer inte går att dela upp jämt mellan antalet grupper
			int placeholdersPerGroup = SetPlaceHolders(numberOfPeople, numberOfGroups, rest);
			
			IList<string> allPersonsList = allPersonsArray.ToList();            //Skapa en lista för att lägga till placeholders

			//allPersonsList = AddPlaceHoldersToList();
			int addNumberToList = numberOfGroups - rest;
			for (int i = 0; i < addNumberToList; i++)
			{
				allPersonsList.Add("");
			}
			
			//CreateA_2D_Array();
			string[,] theGroups2DArray = new string[numberOfGroups, placeholdersPerGroup];

			//PopulateThe_2D_Array();
			//Bakvänd ordning på att populera listan för att sprida personerna så jämt som möjligt.
			int k = 0;
			for (int i = 0; i < placeholdersPerGroup; i++)
			{
				for (int j = 0; j < numberOfGroups; j++)
				{
					theGroups2DArray[j, i] = allPersonsList[k];
					k++;
				}
			}

			Console.WriteLine();

			//PrintResult();
			for (int i = 0; i < numberOfGroups; i++)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"Grupp {i+1}:");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine("¯¯¯¯¯¯¯¯");
				Console.ResetColor();
				for (int j = 0; j < placeholdersPerGroup; j++)
				{
					if (!(theGroups2DArray[i, j] == ""))
					{
                        Console.ForegroundColor = ConsoleColor.Black;
						string trimmedName = theGroups2DArray[i, j].Trim();
						Console.WriteLine(trimmedName);
					}
					
				}
				Console.WriteLine();
			}
		}

		private static int SetPlaceHolders(int numberOfPeople, int numberOfGroups, int rest)
		{
			int placeholdersPerGroup = numberOfPeople / numberOfGroups; //Ifall det inte blir ett jämt antal
			
			if (rest != 0)
			{
				placeholdersPerGroup++;
			}
			return placeholdersPerGroup;
		}

		private static int GetNumberOfGroups(int totalNumberOfGroupsPoss)
		{
            // TODO: lägg gärna in en redundancy mot att användaren anger t ex en bokstav eller tom sträng
			Console.Write($"Ange hur många grupper du vill skapa (du kan ange max {totalNumberOfGroupsPoss} grupper): ");
			int numberOfGroups = Convert.ToInt32(Console.ReadLine());
			return numberOfGroups;
		}

		private static string GetListOfNames()
		{
			Console.Write("Ange alla som ska delas in i grupp: ");
			string allPersonsString = Console.ReadLine();
			return allPersonsString;
		}

		public static void ShuffleArray(string[] a)
		{
			int n = a.Length;
			Random rand = new Random();

			for (int i = 0; i < n; i++)
			{
				Swap(a, i, i + rand.Next(n - i));
			}
		}

		public static void Swap(string[] allPersonsArray, int a, int b)
		{
			string temp = allPersonsArray[a];
			allPersonsArray[a] = allPersonsArray[b];
			allPersonsArray[b] = temp;
		}
	}
}
