    data.GroupBy(r => new { r.Id })
         .Select(g => new
                      {
                          Key = g.Key,
                          Value = g.Sum(s => s.Value),
                          Name = g.First().Name,
                          Category = g.First().Category });
