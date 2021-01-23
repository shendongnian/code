    public static int GetWeekOfMonth(DateTime dateTime)
    {
        DayOfWeek dayOfWeek = dateTime.DayOfWeek;
        DateTime dayStep = new DateTime(dateTime.Year, dateTime.Month, 1);
        int returnValue = 0;
    
        while (dayStep <= dateTime)
        {
            if (dayStep.DayOfWeek == dayOfWeek)
            {
                returnValue++;
            }
    
            dayStep = dayStep.AddDays(1);
        }
    
        return returnValue;
    }
