    var query = range1.Where(x.OpenedDate >= todayFirst && x.OpenedDate <= todayLast)
                      .GroupBy(x => x.ItemId)
                      .Select(g => new { ItemId = g.Key, Count = g.Count());
    foreach (var result in query)
    {
        Console.WriteLine("{0} - {1}", result.ItemId, result.Count);
    }
