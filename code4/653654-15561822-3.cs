    foreach (var info in headINFO)
    {
        Console.WriteLine(info.Key);          // Print Dictionary Key
        Console.WriteLine(info.Value.Item1);  // Prints Turple Value 1
        Console.WriteLine(info.Value.Item2);  // Prints Turple Value 2
    }
