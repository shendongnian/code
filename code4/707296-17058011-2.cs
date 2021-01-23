    IEnumerable<LocalDate> GetSundayToWednesday(int year, int month, int week)
    {
        LocalDate date = new LocalDate(year, month, 1).PlusDays(-1);        
        for (int i = 0; i < week; i++)
        {
            date = date.Next(IsoDayOfWeek.Sunday);
        }
        // You always want 4 days, Sunday to Wednesday
        for (int i = 0; i < 4; i++)
        {
            yield return date;
            date = date.PlusDays(1);
        }
    }
