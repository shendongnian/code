    var query = fooList.GroupBy(f => f.Id, f => f.Bar);
    // Iterate over each grouping in the collection. 
    foreach (var group in query)
    {
        // Print the key value.
        Console.WriteLine(group.Key);
        // Iterate over each value in the  
        // grouping and print the value. 
        foreach (int bar in group)
            Console.WriteLine("  {0}", bar);
    }
