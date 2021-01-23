    IEnumerable<DateTime> GetSundayToWednesday(int year, int month, int week)
    {
        DateTime date = default(DateTime);
        for (int day = week * 7 + 1; day < week * 7 + 8; day++)
        {
            date = new DateTime(year, month, day);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                break;
            }
        }
        // You always want 4 days, Sunday to Wednesday
        for (int i = 0; i < 4; i++)
        {
            yield return date;
            date = date.AddDays(1);
        }
    }
