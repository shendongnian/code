    int CountHolidaysBetween(DateTime start, DateTime end) {
        int days = end.Day.Substract(start.Day).Days;
        return Enumerable.Range(0, days + 1)
                         .Select(day => start.Day.AddDays(day))
                         .Count(d => d.IsHoliday());
    }
