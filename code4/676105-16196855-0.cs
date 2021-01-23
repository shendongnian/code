    TimeSpan ts = new TimeSpan(0, 0, 5);  // 5 seconds
    entries.GroupBy(i => new {
                              i.UserId, 
                              i.CompanyId, 
                              i.Target, 
                              (long)(Math.Round((decimal)i.CreationDate.Ticks / ts.Ticks) * ts.Ticks);
                              ))
           .Select( ... );
