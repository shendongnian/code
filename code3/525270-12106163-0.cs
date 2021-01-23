    using(var dataContext = new YourDataContext())
    {
        var dictionary = dataContext.CDRs.GroupBy(u => new
        {
            u.StartTime.Year,
            u.StartTime.Month,
            u.StartTime.Day
        })
        .Select(g => new{ Date = g.Key, Count = g.Count() })
        .ToDictionary(g => new DateTime(g.Key.Year, g.Key.Month, g.Key.Day), g=>g.Count);
        return dictionary;
    }
