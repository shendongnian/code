    public static List<double> GetHoursBetweenDates(List<DateTime> aDates)
    {
        return aDates.OrderByDescending(d => d)
                     .Incremental((p,n) => p.Subtract(n).TotalHours)
                     .ToList();
    }
