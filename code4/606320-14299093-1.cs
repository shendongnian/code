    var lines = File.ReadLines(csvFilePath);
    var custItems = lines
        .Select(l => new { split = l.Split() })
        .Select(x => new { customer = x.split[0].Trim(), item = x.split[1].Trim() })
        .ToList();
    var groups = from ci1 in custItems
                 join ci2 in custItems
                 on ci1.customer equals ci2.customer
                 where ci1.item != ci2.item 
                 group new { Item1 = ci1.item, Item2 = ci2.item } by new { Item1 = ci1.item, Item2 = ci2.item } into ItemGroup
                 select ItemGroup;
    var result = groups.Select(g => new
    {
        g.Key.Item1,
        g.Key.Item2,
        how_many_custs_bought_both = g.Count()
    });
