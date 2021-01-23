    public static DateTime GetIsraelTime(DateTime d) {
        d = d.AddHours(2);           // Israel is at GMT+2
    
        // April 2nd, 2:00 AM
        DateTime DSTStart = new DateTime(d.Year, 4, 2, 2, 0 ,0);  
        while (DSTStart.DayOfWeek != DayOfWeek.Friday)
            DSTStart = DSTStart.AddDays(-1);
    
        CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
        System.Globalization.HebrewCalendar cal = 
              new System.Globalization.HebrewCalendar();
        jewishCulture.DateTimeFormat.Calendar = cal;
        // Yom HaKipurim, at the start of the next Jewish year, 2:00 AM
        DateTime DSTFinish =
             new DateTime(cal.GetYear(DSTStart)+1, 1, 10, 2, 0 ,0, cal);
        while (DSTFinish.DayOfWeek != DayOfWeek.Sunday)
            DSTFinish= DSTFinish.AddDays(-1);
    
        if (d>DSTStart && d<DSTFinish)
            d = d.AddHours(1);
    
        return (d);
    }
