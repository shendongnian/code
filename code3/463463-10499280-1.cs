    // Just setup some test data simulary to your example
    IList<Data> testList = new List<Data>();
    DateTime date = DateTime.Parse("6:00"); 
    
    // This loop fills just some data over several years, months and days
    for (int year = date.Year; year > 2010; year--)
    {
        for(int month = date.Month; month > 0; month--)
        {
            for (int day = date.Day; day > 0; day--)
            {
                for(int hour = date.Hour; hour > 0; hour--)
                {
                    DateTime testDate = date.AddHours(-hour).AddDays(-day).AddMonths(-month).AddYears(-(date.Year - year));
                    testList.Add(new Data() { Start = testDate, End = testDate.AddMinutes(30), Value = 1 });
                    testList.Add(new Data() { Start = testDate.AddMinutes(30), End = testDate.AddHours(1), Value = 1 });
                }
            }
        }
    }
    
    // The actual query which does to trick
    var result =
        from d in testList
        group d by new { d.Start.Year, d.Start.Month, d.Start.Day, d.Start.Hour } into g
        select new Data() { Start = g.Min(m => m.Start), End = g.Max(m => m.End), Value = g.Sum(m => m.Value) };
