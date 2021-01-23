    var a = new Version("1.0.1");
    var b = new Version("2.0.0");
	
    int comparison = a.CompareTo(b);
	
    if(comparison > 0)
    {
        Console.WriteLine("A is a greater version.");
    } 
    else if(comparison == 0)
    {
        Console.WriteLine("A and B are the same version.");
    }	
    else
    {
        Console.WriteLine("B is a greater version.");
    }
