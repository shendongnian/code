    var sqlMinDate = (DateTime) SqlDateTime.MinValue;
    var trendData = ExpenseItemsViewableDirect
        .GroupBy(x => SqlFunctions.DateAdd("month", SqlFunctions.DateDiff("month", sqlMinDate, x.Er_Approved_Date), sqlMinDate))
        .Select(x => new
        {
            Period = g.Key // DateTime type
        })
