    int weekNumber(DateTime fromDate)
    {
        // Get jan 1st of the year
        DateTime startOfYear = fromDate.AddDays(- fromDate.Day + 1).AddMonths(- fromDate.Month +1);
        // Get dec 31st of the year
        DateTime endOfYear = startOfYear.AddYears(1).AddDays(-1);
        // ISO 8601 weeks start with Monday 
        // The first week of a year includes the first Thursday 
        // DayOfWeek returns 0 for sunday up to 6 for saterday
        int[] iso8601Correction = {6,7,8,9,10,4,5};
        int nds = fromDate.Subtract(startOfYear).Days  + iso8601Correction[(int)startOfYear.DayOfWeek];
        int wk = nds / 7;
        switch(wk)
        {
            case 0 : 
                // Return weeknumber of dec 31st of the previous year
                return weekNumber(startOfYear.AddDays(-1));
            case 53 : 
                // If dec 31st falls before thursday it is week 01 of next year
                if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                    return 1;
                else
                    return wk;
            default : return wk;
        }
    }
