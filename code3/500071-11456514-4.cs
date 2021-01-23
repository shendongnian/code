    // Assumes IEnumerable<DateTime> dbDates;
    var remaining =
        Enumerable.Range(0, Int32.MaxValue)
                  .Select(day => startDate.AddDays(day))
                  .Where(d => d <= endDate)
                  .Except(dbDates);
