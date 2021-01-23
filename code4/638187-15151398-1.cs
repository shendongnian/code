    public static string GetWeekOfMonth(DateTime dateTime)
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
    
        switch (returnValue % 100)
        {
            case 11:
            case 12:
            case 13:
                return returnValue.ToString() + "th";
        }
    
        switch (returnValue % 10)
        {
            case 1:
                return returnValue.ToString() + "st";
            case 2:
                return returnValue.ToString() + "nd";
            case 3:
                return returnValue.ToString() + "rd";
            default:
                return returnValue.ToString() + "th";
        }
    }
