    var source = new List<Dictionary<string, object>>();
    // (...)
    var maxColumnLengths = source.SelectMany(x => x)
                                 .GroupBy(x => x.Key)
                                 .ToDictionary(g => g.Key,
                                               g => g.Max(x => x.Value.ToString().Length));
