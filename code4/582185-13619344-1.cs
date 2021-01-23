    var dailyUsages = context.UsageData
         .Where(u => u.UserID == CurrentUser.ID &&
                     u.Date >= start && 
                     u.Date <= end)
         .Select(p => new PerfData()
                      {
                          Date = p.Date,
                          Transfers = p.Transfers,
                          Exists = p.Exists,
                          Duration = p.Duration
                      }).ToList();
    var dates = (from date in GetDateRange(start, end)
                 join dailyUsage in dailyUsages on date equals dailyUsage.Date into grp
                 from item in grp.DefaultIfEmpty(new PerfData()
                                                 {
                                                     Date = date,
                                                     Transfers = 0,
                                                     Exists = 0,
                                                     Duration = 0
                                                 })
                 select item).ToList();
    
