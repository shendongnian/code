	var numbersList = new List<int>();
	
	while(numbersList.Count <= 5)
	{
		int input = Convert.ToInt32(Console.ReadLine());
		if(input >= 10 && input <= 50)
		{
			numbersList.Add(input);
			continue;
		}
		
		Console.WriteLine("The number you entered is either to high or to low please re-enter a number:");
	}
