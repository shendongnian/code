    IEnumerable<int> sequence = new[] { complexIntGenerationMethiod(), 1, 2, 3, 4 }
        .SingleEnumeration();
    
    foreach (int i in sequence) //based on origional iteration
    {
        Console.WriteLine(i);
    }
    
    foreach (int i in sequence) //will be based on cache entry
    {
        Console.WriteLine(i);
    }
    
    private static int complexIntGenerationMethiod()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Complex method");
        return 0;
    }
