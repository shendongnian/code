    public int CountBusinessDaysBetween(DateTime start, DateTime end) {
        int days = end.Subtract(start).Days;
        return Enumerable.Range(0, days)
                         .Select(day => start.AddDays(day))
                         .Where(date => date.IsBusinessDay())
                         .Count();
    }
