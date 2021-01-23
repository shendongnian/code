    IEnumerable<DateTime> GetSundayToWednesday(int year, int month, int week)
    {
        // Consider breaking this part out into a separate method?
        DateTime date = new DateTime(year, month, week * 7 + 1);
        for (int i = 0; i < 7; i++)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                break;
            }
            date = date.AddDays(1);
        }
        // You always want 4 days, Sunday to Wednesday
        for (int i = 0; i < 4; i++)
        {
            yield return date;
            date = date.AddDays(1);
        }
    }
