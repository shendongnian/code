    using (var db = new DbContainer())
    {
       var groups = db.Table
                      .Select(row => row.Time)
                      .GroupByConsecutive((prev, next) => next.Subtract(prev)
                                                              .TotalSeconds <= 5)
                      .Take(count)
                      .ToList();
      // Use groups...
    
    }
