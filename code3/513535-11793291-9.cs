    private IEnumerable<DateTime> GetDatesOfSundays(DateTime DatMonth)
    {
        int iDayOffset = DatMonth.Day - 1;   
        DatMonth = DatMonth.AddDays(System.Convert.ToDouble(-DatMonth.Day + 1));
        DateTime DatMonth2 =
            DatMonth.AddMonths(1).AddDays(System.Convert.ToDouble(-1));
        while (DatMonth < DatMonth2)
        {
            if (DatMonth.DayOfWeek == System.DayOfWeek.Sunday)
            {
                yield return DatMonth;
            }
     
            DatMonth = DatMonth.AddDays(1.0);
        }
    }
