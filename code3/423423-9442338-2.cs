    private bool IsLastMonday(DateTime date)
    {
        if (date.DayOfWeek != DayOfWeek.Monday) 
            return false; // it is not monday
        // the next monday is...
        var oneWeekAfter = date.AddDays(7);
        // and is it in same month?, if it is, that means its not last monday
        return oneWeekAfter.Month != date.Month;
    }
