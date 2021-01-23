    public static IEnumerable<DateTime> Last(this DayOfWeek dow, int count)
    {
        var today = DateTime.Today;
        var adjustment = (dow - today.DayOfWeek + 1) % 7;
        return Enumerable.Range(0, count)
                         .Select(x => today.AddDays(x * -7 - adjustment));
    }
