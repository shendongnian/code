    var occurrences = userSelect
      .Where(lookup.Contains)
      .SelectMany((s, i) => lookup[s]
        .Select(j => new {
          User = userSelect.Skip(i),
          Original = original.Skip(j),
          Skipped = i
        })
        .Select(t => t.User.Zip(t.Original, (u, v) => Tuple.Create(u, v, t.Skipped))
                           .TakeWhile(tuple => tuple.Item1 == tuple.Item2)
        )
        .Select(u => new { 
          Word = s, 
          Start = u.Select(v => v.Item3).Min(), 
          Length = u.Count()
        })
      )
      .GroupBy(v => v.Start + v.Length)
      .Select(g => g.OrderBy(u => u.Start).First())
      .GroupBy(v => v.Word)
      .Select(g => g.OrderByDescending(u => u.Length).First())
      .Select(w => Enumerable.Range(w.Start, w.Length).ToArray())
      .ToList();
