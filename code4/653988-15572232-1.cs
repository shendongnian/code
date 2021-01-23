    var groupByReference = context.Measurements
                                  .GroupBy(m => m.Reference)
                                  .Select(g => new {Creation = g.First().CreationTime, 
                                                    Avg = g.Average(m => m.CreationTime.Ticks),
                                                    Items = g })
                                  .OrderBy(x => x.Creation)
                                  .ThenBy(x => x.Avg)
                                  .Take(numOfEntries)
                                  .ToList();
