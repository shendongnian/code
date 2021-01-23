    public static bool MyCustomDateCompare(DateTime one, DateTime two)
    {
        return (one.Year  == two.Year  &&
                one.Month == two.Month &&
                one.Day   == two.Day   &&
                one.Hour  == two.Hour  && 
                ...);
    }
