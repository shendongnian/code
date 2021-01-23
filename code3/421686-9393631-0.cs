       const string input = "Casual Leave:12-Medical Leave :13-Annual Leave :03 ";   	
       // Split on one or more non-digit characters.
       string[] numbers = Regex.Split(input, @"\D+");
       foreach (string value in numbers)
    	{
    	    if (!string.IsNullOrEmpty(value))
    	    {
    		int i = int.Parse(value);
    		Console.WriteLine("Number: {0}", i);
    	    }
    	}
