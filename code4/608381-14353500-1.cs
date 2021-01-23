    // Materialize the result to avoid computing possibly different sequences
    var allDatesAndNow = GetDatesOrdered().Concat(DateTime.Now).ToList();
    // For each value and its subsequent one, work out whether it's enabled
    // or not and the duration
    return allDatesNow.Zip(allDatesNow.Skip(1),
                           (x, y) => new { Enabled = GetEnabled(x),
                                           Duration = y - x })
    // Filter to only include the enabled ones
                      .Where(x => x.Enabled)
    // Now sum all the results using aggregation
                      .Aggregate(TimeSpan.Zero, (t, pair) => t + pair.Duration);
