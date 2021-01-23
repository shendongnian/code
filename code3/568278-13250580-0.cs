      return fileRawList.Where(file => file.Time >= beginDate)
                        .Where(file => file.Time < endofLoopDate)
                        .GroupBy(file => file.Time.Ticks / timeSpan.Ticks,
                                 g => new OHLC()
                                      {
                                        Open = g.Select(p => p.Bid).DefaultIfEmpty().First(),
                                        High = g.Select(p => p.Bid).DefaultIfEmpty().Max(),
                                        Low = g.Select(p => p.Bid).DefaultIfEmpty().Min(),
                                        Close = g.Select(p => p.Bid).DefaultIfEmpty().Last(),
                                        Time = g.Select(p => p.Time).DefaultIfEmpty(iLow).First()
                                              })
                         .ToList();
