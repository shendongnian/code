    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace OefeningExaam
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Random getal              = new Random();
    			int[]  lottotrekking      = new int[6];
    			int[]  userInput          = new int[6];
    			bool   isLotteryWon       = false;
    			int    numberOfIterations = 0;
    			Console.WriteLine("Geef je geluksgetallen in <tussen 1 en 42>");
    			Console.WriteLine("Geef je eerste getal in");
    			userInput[0] = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("Geef je tweede getal in");
    			userInput[1] = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("Geef je derde getal in");
    			userInput[2] = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("Geef je vierde getal in");
    			userInput[3] = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("Geef je vijfde getal in");
    			userInput[4] = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("Geef je zesde getal in");
    			userInput[5] = Convert.ToInt32(Console.ReadLine());
    
    			while (!isLotteryWon)
    			{
    				isLotteryWon = true;
    
    				// Generate the lottery numbers
    				for (int i = 0; i < lottotrekking.Length; i++)
    				{
    					int newNumber = getal.Next(1, 43);
    
    					while (Program.IsContained(lottotrekking, newNumber))
    						newNumber = getal.Next(1, 43);
    
    					lottotrekking[i] = newNumber;
    				}
    
    
    				Console.WriteLine(lottotrekking[0] + "\t " + lottotrekking[1] + "\t " + lottotrekking[2] + "\t " + lottotrekking[3] + "\t " + lottotrekking[4] + "\t " + lottotrekking[5]);
    
    				//Compare lottery numbers to user input, if they match and are in the same order, the user wins.
    				for (int i = 0; i < lottotrekking.Length; i++)
    					isLotteryWon &= Program.IsContained(lottotrekking, userInput[i]);
    
    				numberOfIterations++;
    			}
    
    			Console.WriteLine(string.Format("Lottery won in {0} iterations", numberOfIterations));
    			Console.ReadLine();
    		}
    
    		/// <summary>
    		/// Determines whether the specified number is contained in the collection.
    		/// </summary>
    		/// <param name="collection">The collection.</param>
    		/// <param name="number">The number.</param>
    		/// <returns>
    		///   <c>true</c> if the specified number is contained in the collection; otherwise, <c>false</c>.
    		/// </returns>
    		private static bool IsContained(int[] collection, int number)
    		{
    			for (int i = 0; i < collection.Length; i++)
    			{
    				if (collection[i] == number)
    					return true;
    			}
    			return false;
    		}
    	}
    }
