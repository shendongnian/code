        .Select(g =>
          new { 
            Key = g.Key, 
            Items = 
              g
                .GroupBy(r => r.Year)
                .SelectMany(gy =>
                  gy.Concat(
                    Enumerable.Range(1,5)
                      .Where(q => !gy.Any(r=>r.Quarter == q))
                      .Select(q => new { Problem = g.Key, Year = gy.Key, Quarter = q, Count = 0 })
                  )
                )
          }
        )
