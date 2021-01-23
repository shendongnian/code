    for (var i = 0; i <= days; i++)
    {
        var testDate = sDate.AddDays(i);
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
    }
