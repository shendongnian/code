    public static bool YearMonthDayHourDateCompare(DateTime one, DateTime two)
    {
        return (one.Year  == two.Year  &&
                one.Month == two.Month &&
                one.Day   == two.Day   &&
                one.Hour  == two.Hour  && 
                ...);
    }
