    foreach(var entry in result)
    {
        foreach (var dim in entry.Dimension) 
              Console.WriteLine(dim.Key + " = " + dim.Value);
        Console.WriteLine();
        foreach (var met in entry.Metric) 
              Console.WriteLine(met.Key + " = " + met.Value);
        Console.WriteLine("---------------");
    }
