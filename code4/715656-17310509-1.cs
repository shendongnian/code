    public static IEnumerable<DateTime> Last(this DayOfWeek dow, int count)
    {
        var today = DateTime.Today;
        var adjustment = today.DayOfWeek - dow + (dow > today.DayOfWeek ? 7 : 0);
        return Enumerable.Range(0, count)
                         .Select(x => today.AddDays(x * -7 - adjustment));
    }
