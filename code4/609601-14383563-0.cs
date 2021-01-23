    int year = 2013;
    DateTime testDate = new DateTime(year,1,1);
    
    
    while ( testDate.DayOfWeek != DayOfWeek.Monday )
    {
       testDate = testDate.AddDays(1);
    }
