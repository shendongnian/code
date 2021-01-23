    var end = start + TimeSpan.FromMinutes(15);
    // Avoid querying more than once.
    var matches = input.Where(x => x.Time >= start && x.Time < end)
                       .ToList();
    // TODO: Consider what you want to do if there are no matches.
    // (The code below would fail.)
    var max = matches.Max(x => x.Value);
    var min = matches.Min(x => x.Value);
    var open = matches.First().Value;
    var close = matches.Last().Value;
