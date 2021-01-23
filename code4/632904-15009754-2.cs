    var byDayOfWeek = collectionOfDateTime.GroupBy(dt => dt.DayOfWeek);
    // Optionally convert to a dictionary by day of week
    var asDict = byDayOfWeek.ToDictionary(grp => grp.Key, grp => grp.ToList());
    
    foreach(var kvp in asDict)
    {
        Console.WriteLine("Day:" + kvp.Key);
        foreach (var value in kvp.Value)
        {
            Console.WriteLine(value);
        }
    }
