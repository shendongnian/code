    public static double ConvertHoursToTotalDays(double hours)
    {
        TimeSpan result = TimeSpan.FromHours(hours);
        
        return result.TotalDays;
    }
