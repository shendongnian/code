    string l = Console.ReadLine();
    
    int line = 0;
    
    while(!int.TryParse(l, out line))
    {
    	Console.WriteLine("Try again.");
    	l = Console.ReadLine();
    }
    
    // num contains a valid number here.
