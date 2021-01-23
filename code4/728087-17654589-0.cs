    var rowsTotals = from s in saleList
        orderby s.MonthYear
        group s by new { Year = s.MonthYear.Year, Month = s.MonthYear.Month } into grp
        select new
        {
            Key = grp.Key,
            FullMonthTotal = grp.Sum (x => x.FullMonth),
            DaysMonthTotal = grp.Sum (x => x.DaysMonth)
        };
