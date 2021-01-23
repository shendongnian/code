    // build sample data with 1200 Strings
    string[] items = Enumerable.Range(1, 1200).Select(i => "Item" + i).ToArray();
    // split on groups with each 100 items
    String[][] chunks = items
                        .Select((s, i) => new { Value = s, Index = i })
                        .GroupBy(x => x.Index / 100)
                        .Select(grp => grp.Select(x => x.Value).ToArray())
                        .ToArray();
    
    for (int i = 0; i < chunks.Length; i++)
    {
        foreach (var item in chunks[i])
            Console.WriteLine("chunk:{0} {1}", i, item);
    }
