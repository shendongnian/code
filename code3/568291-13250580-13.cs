    var rawGroups = fileRawList.Where(file => file.Time >= beginDate)
                        .Where(file => file.Time < endofLoopDate)
                        .ToLookup(file => (file.Time.Ticks - beginDate.Ticks) / timeSpan.Ticks,
                                  file => new {Bid = file.Bid, Time = file.Time})
                        .ToDictionary( g => g.Key, g => new OHLC()
                                      {
                                        Open = g.Select(p => p.Bid).DefaultIfEmpty().First(),
                                        High = g.Select(p => p.Bid).DefaultIfEmpty().Max(),
                                        Low = g.Select(p => p.Bid).DefaultIfEmpty().Min(),
                                        Close = g.Select(p => p.Bid).DefaultIfEmpty().Last(),
                                        Time = g.Select(p => p.Time).DefaultIfEmpty().First()
                                              });
    
    return Enumerable.Range(0,(Int32)((endofLoopDate.Ticks - beginDate.Ticks)/timeSpan.Ticks))
                     .Select(i => rawGroups.Keys.Contains(i) ? 
                                  rawGroups[i] :
                                  new OHLC()
                                  {
                                   Open = 0,
                                   High = 0,
                                   Low = 0,
                                   Close = 0,
                                   Time = new DateTime(beginDate.Ticks + i*timeSpan.Ticks)
                                  }).ToList();
