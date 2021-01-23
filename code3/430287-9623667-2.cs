    var lookup = list.ToLookup(x => x.CreatedOnDateTime);
    foreach (var entry in lookup)
    {
        Console.WriteLine("Created: {0}", entry.Key);
        foreach (var item in entry)
        {
            Console.WriteLine("  {0}, {1}", item.Name, item.Field2);
        }
    }
