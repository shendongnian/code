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
    var dates = from date in GetDateRange(start, end)
                join dailyUsage in dailyUsages on date equals dailyUsage.Date into grp
                select new { Date = date, DailyUsages = grp.ToList() };
    
