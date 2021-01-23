    while (Again())
    {
    	Random ran = new Random();
    	int num1 = ran.Next(1, 7);
    	int num2 = ran.Next(1, 7);
    	//if else statement determining the output for each roll in the console.
    	if (num1 == NUM_6 && num2 == NUM_6)
    	{
    		Console.WriteLine("\nYou Rolled BoxCars");
    	}
    	else if (num1 == NUM_1 && num2 == NUM_1)
    	{
    		Console.WriteLine("\nYou rolled Snake-Eyes");
    	}
    	else 
    	{
    		Console.WriteLine("\nYou Rolled...{0} and {1}", num1, num2);
    	}
    }
