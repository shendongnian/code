    var testDate = DateTime.Now;
    
    while (testDate <= eDate)
    {
        switch (testDate.DayOfWeek)
        {
           case DayOfWeek.Saturday:
           case DayOfWeek.Sunday:
                allWeekEndsInOneYear.Add(testDate);
                break;
           default:
                daysToMark.Add(testDate); // this is a workday
                break;
        }
    
        testDate = testDate.AddDays(1);
    }
