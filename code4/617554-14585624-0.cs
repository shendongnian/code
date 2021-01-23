    List<string> ops = new List<string>();
    AddServer asvr = new AddServer("newName", "newSeed", ops);
    
    Console.WriteLine(asvr.Name);
    Console.WriteLine(asvr.Seed);
    Console.WriteLine(asvr.Ops.Count);
