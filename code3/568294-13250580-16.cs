    var result = Enumerable.Range(0,(Int32)((endofLoopDate.Ticks - beginDate.Ticks)/timeSpan.Ticks))
                           .GroupJoin(fileRawList.Where(file => file.Time >= beginDate)
                                                 .Where(file => file.Time < endofLoopDate)
                                                 .OrderBy(file => file.Time),
                                      i => i,
                                      file => (file.Time.Ticks - beginDate.Ticks) / timeSpan.Ticks,
                                      (k,g) => new OHLC()
                                          {
                                           Open = g.Select(p => p.Bid).DefaultIfEmpty(0).First(),
                                           High = g.Select(p => p.Bid).DefaultIfEmpty(0).Max(),
                                           Low = g.Select(p => p.Bid).DefaultIfEmpty(0).Min(),
                                           Close = g.Select(p => p.Bid).DefaultIfEmpty(0).Last(),
                                           Time = g.Any() ? 
                                             g.Select(p => p.Time).First() :
                                             new DateTime(beginDate.Ticks + i*timeSpan.Ticks)
                                          })
