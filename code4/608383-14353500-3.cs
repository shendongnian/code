    // Materialize the result to avoid computing possibly different sequences
    var allDatesAndNow = GetDatesOrdered().Concat(new[] { DateTime.Now })
                                          .ToList();
    return allDatesNow.Zip(allDatesNow.Skip(1),
                           (x, y) => new { Enabled = GetEnabled(x),
                                           Duration = y - x })
                      .Where(x => x.Enabled)
                      .Aggregate(TimeSpan.Zero, (t, pair) => t + pair.Duration);
