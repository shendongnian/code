    public static IEnumerable<DateTime> GetDays(this IEnumerable dates, DayOfWeek day)
    {
         var start = dates.Min();
         var end = dates.Max();
         return Enumerable
                .Range(0, end.Subtract(start).Days + 1).Select(offset => start.AddDays(offset))
                .Where(d => d.DayOfWeek == day);             
    }
