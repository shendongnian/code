    var query = types.GroupBy(t => t.Type)
                     .Select(g => new { Type = g.Key, Count = g.Count() });
    foreach (var result in query)
    {
        Console.WriteLine("{0}, {1}", result.Type, result.Count);
    }
