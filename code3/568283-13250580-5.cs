    var rawGroups = fileRawList.Where(file => file.Time >= beginDate)
                        .Where(file => file.Time < endofLoopDate)
                        .ToLookup(file => (file.Time.Ticks - beginDate.Ticks) / timeSpan.Ticks)
                        .ApplyResultSelector( (k,g) => new OHLC()
                                      {
                                        Open = g.Select(p => p.Bid).DefaultIfEmpty().First(),
                                        High = g.Select(p => p.Bid).DefaultIfEmpty().Max(),
                                        Low = g.Select(p => p.Bid).DefaultIfEmpty().Min(),
                                        Close = g.Select(p => p.Bid).DefaultIfEmpty().Last(),
                                        Time = g.Select(p => p.Time).DefaultIfEmpty().First()
                                              });
    
    return Enumerable.Range((endofLoopDate.Ticks - beginDate.Ticks)/timeSpan.Ticks,0)
                     .Select(i => new { index = i, Ohlc = new OHLC()
                                  {
                                   Open = 0,
                                   High = 0,
                                   Low = 0,
                                   Close = 0,
                                   Time = new DateTime(beginDate.Ticks + i*timeSpan.Ticks)
                                  }})
                      .Select(anon => rawGroups.Contains(anon.Index) ? 
                                      rawGroups[anon.Index] :
                                      anon.Ohlc).ToList();
