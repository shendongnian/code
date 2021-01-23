    TimeSpan ts = new TimeSpan(0, 0, 5);  // 5 seconds
    entries.GroupBy(i => new {
                              UserId = i.UserId, 
                              CompanyId = i.CompanyId, 
                              Target = i.Target, 
                              RoundedTime = DateTime.MinValue.AddTicks(
                                                (long)(Math.Round((decimal)i.CreationDate.Ticks / ts.Ticks) * ts.Ticks)
                                            ) ;
                              ))
           .Select(g => new {
                             UserId = g.Key.UserId, 
                             CompanyId = g.Key.CompanyId, 
                             Target = g.Key.Target, 
                             RoundedTime = g.Key.RoundedTime,
                             Message = string.Join(", ",g.Select(i=> i.Message).ToArray())
                            } );
