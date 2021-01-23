	static void Main(string[] args) 
	{
	
		Random random = new Random();
	
		int returnValue = random.Next(1, 100);
		int Guess = 0;
		int numGuesses = 0;
	
		Console.WriteLine("I am thinking of a number between 1-100.  Can you guess what it is?");
	
		while (Guess != returnValue)
		{
			Guess = Convert.ToInt32(Console.Read());
			string line = Console.ReadLine(); // Get string from user
			if (!int.TryParse(line, out Guess)) // Try to parse the string as an integer
				Console.WriteLine("Not an integer!");
			else {
				numGuesses++;
				if (Guess < returnValue)
				{
					Console.WriteLine("No, the number I am thinking of is higher than " + Guess + " .  Can you guess what it is?");
				}
				if (Guess > returnValue)
				{
					Console.WriteLine("No, the number I am thinking of is lower than " + Guess + " .  Can you guess what it is");
				}
			}
		}
		Console.WriteLine("Well done! The answer was " + returnValue + ".\nYou took " + numGuesses + " guesses.");
	}
