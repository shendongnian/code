    for (int year = startDate.Year; year <= endDate.Year; year++)
    {
        foreach (var pair in monthDays)
        {
            // Avoid creating a date which doesn't exist...
            if (!DateTime.IsLeapYear(year) && pair.Month == 2 && pair.Day == 29)
            {
                continue;
            }
            DateTime date = new DateTime(year, pair.Month, pair.Day);
            if (date <= startDate && date <= endDate)
            {
                results.Add(date);
            }
        }
    }
