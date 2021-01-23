    IQueryable<UserStatistic> GetPastMonths(int months)
    {    
        var limitDay = date.AddMonths(-months).Date;
        var limit = new DateTime(limitDay.Year, limitDay.Month, 1, 0, 0, 0, 0);
        var placeHolders = Enumerable.Range(0, months + 1)
            .Select(m =>
                new UserStatistic
                    {
                        Date = limit.AddMonths(-m),
                        UserCount = 0
                    });
        var data = Database.Users
            .Where(i => i.RegisterDate >= limit)
            .GroupBy(i => new {y=i.RegisterDate.Year, m = i.RegisterDate.Month})
            .Select(g => 
                new UserStatistic
                    { 
                        Date = EntityFunctions.CreateDateTime(
                                g.Key.y,
                                g.Key.m, 
                                1, 
                                0, 
                                0, 
                                0),
                        UserCount = g.Count(o => o.Id)
                    });
        return data.Concat(placeHolders
            .Where(p => !data.Any(d => d.Date == p.Date)))
            .AsQueryable();
    }
