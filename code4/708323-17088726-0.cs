    var query4 = query3.ToList(); // Prevent multiple execution.
    var startDate = DateTime.Today.AddDays(-99);
    var emptyData = Enumerable.Range(1,100).Select (i => 
        new ReferrerChart
            {
               Date = startDate.AddDays(i),
               LeadsCount = 0,
               SalesCount = 0
            });
    
    var result = query4 .Union(
                 emptyData
                    .Where(e => !query4.Select(x => x.Date).Contains(e.Date)))
                 .OrderBy(x => x.Date);
