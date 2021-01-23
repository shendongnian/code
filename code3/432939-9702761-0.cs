    // To get a Dictionary<string, int>
    var counts = list.GroupBy(x => x)
                     .ToDictionary(g => g.Key, g => g.Count());
    // To just get a sequence
    var counts = list.GroupBy(x => x)
                     .Select(g => new { Text = g.Key, Count = g.Count() });
