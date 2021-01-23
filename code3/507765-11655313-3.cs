        DateTime date = DateTime.Today;
        DateTime firstOfMonth = new DateTime(date.Year, date.Month, 1);
        DateTime twelveMonthAgoFirstOfMonth = firstOfMonth.AddMonths(-12);
        var monthYears = Enumerable.Range(-12, 12).Select(monthOffset => { DateTime monthDate = firstOfMonth.AddMonths(monthOffset); return new { y = monthDate.Year, m = monthDate.Month }; });
        
        var data = (from monthYear in monthYears
                    join i in (from i in Database.Users
                               where i.RegisterDate >= twelveMonthAgoFirstOfMonth && i.RegisterDate < firstOfMonth
                               group i by new {y = i.RegisterDate.Year, m = i.RegisterDate.Month} into g
                               select new { Key = g.Key, UserCount = g.Count() }) on monthYear equals i.Key into j
                     from k in j.DefaultIfEmpty()
                     select new UserStatistic() { Date = new DateTime(monthYear.y, monthYear.m, 1), UserCount = k != null ? k.UserCount : 0 });
