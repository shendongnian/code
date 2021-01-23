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
    			Random getal         = new Random();
    			int[]  lottotrekking = new int[6];
    			int[]  userInput     = new int[6];
    			bool   isLotteryWon  = true;
    
    			// Generate the lottery numbers
    			for (int i = 0; i < lottotrekking.Length; i++)
    				lottotrekking[i] = getal.Next(1, 43);
    
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
    
    			//Compare lottery numbers to user input, if they match and are in the same order, the user wins.
    			for (int i = 0; i < lottotrekking.Length; i++)
    				isLotteryWon &= lottotrekking[i] == userInput[i];
    
    			if (isLotteryWon)
    				Console.WriteLine("User wins lottery!");
    			else
    				Console.WriteLine("Sorry, you lost, good luck next time!");
    
    			Console.ReadLine();
    		}
    	}
    }
