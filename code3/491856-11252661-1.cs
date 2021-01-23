	for (i = 0; i < 4; i++)
	{
		Console.WriteLine("Please enter test " + i);
		string input = Console.ReadLine();
		int value;
		bool success = int.TryParse(input, out value);
		if (success)
		{
			test[i] = value
		}
		else
		{
			// Show an error message that the user must enter an integer.
		}
		
		Console.ReadLine();
	}				 
