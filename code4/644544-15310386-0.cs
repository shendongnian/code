    int[] items = new[] { 1, 2, 3, 1, 4, 5, 3, 7 };
    var duplicates = items.Select((e, i) => new { e, i })
                          .GroupBy(i => i.e)
                          .Where(g => g.Count() > 1)
                          .Select(g => new { Value = g.Key, Indexes = g.Select(e => e.i).ToList() })
                          .ToList(); 
