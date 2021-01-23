    List<string> Master = new List<string>()
        { "a", "b", "c", "d", "e", "f", "g", "h" };
    List<string> Found = new List<string>() 
        { "g", "d", "e", "h", "a", "b", "c", "f" };
    List<string> missing = Master.Except(Found).ToList();
    
    Console.WriteLine(missing.Count); //Prints 0
