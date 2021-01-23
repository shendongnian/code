    var groupByReference = (from m in context.Measurements
                                  .GroupBy(m => m.Reference)
    							  .Take(numOfEntries).AsEnumerable()
                                   .Select(g => new {Creation = g.FirstOrDefault().CreationTime, 
                                                 Avg = g.Average(m => m.CreationTime.Ticks),
                                                    Items = g })
                                  .OrderBy(x => x.Creation)
                                  .ThenBy(x => x.Avg)
                                  .ToList() select m);
