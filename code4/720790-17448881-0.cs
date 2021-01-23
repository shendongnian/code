    var date = new DateTime(2013, 1, 15);
    
    var nextMonth = date.AddMonths(1);
    
    var firstDay = new DateTime(date.Year, date.Month, 1).DayOfWeek;
    
    var lastDay = new DateTime(nextMonth.Year, nextMonth.Month, 1).AddDays(-1).DayOfWeek;
