        Dictionary<Int64, string> originalCounts = new Dictionary<Int64, string>();
        for (Int64 i = 0; i < 10; i++)
        {
            originalCounts.Add(i, i.ToString());
        }
        originalCounts[5] = originalCounts[3];
        foreach (var kvp in originalCounts)
        {
            Console.WriteLine("{0}  {1}", kvp.Key, kvp.Value);
        }
        Console.WriteLine();
        foreach (var value in originalCounts.Values.Distinct())
        {
            Console.WriteLine("{0}", value);
        }
