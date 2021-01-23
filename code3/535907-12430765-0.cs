    foreach (var group in dynamiclinqquery)
    {
        // Print out the key.
        Console.WriteLine("Key: {0}", group.Key);
    
        // Write the items.
        foreach (var item in group)
        {
            Console.WriteLine("Item: {0}", item);
        }
    }
