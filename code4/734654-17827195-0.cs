    var mainDeckGroups = MainDeck.GroupBy(s => s)
        .Select(g => new { Item = g.Key, Count = g.Count() })
        .Where(x => x.Count > 1)
        .OrderByDescending(x => x.Count);
    foreach (var dup in mainDeckGroups)
        Console.WriteLine("{0}x {1}", dup.Count, dup.Item);
    // other lists ...
