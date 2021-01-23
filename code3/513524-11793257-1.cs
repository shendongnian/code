    private DateTime[] GetDatesOfSundays(DateTime DatMonth)
    {
        List<DateTime> lst = new List<DateTime>();
        int iDayOffset = DatMonth.Day - 1;   
        DatMonth = DatMonth.AddDays(System.Convert.ToDouble(-DatMonth.Day + 1));
        DateTime DatMonth2 = DatMonth.AddMonths(1).AddDays(System.Convert.ToDouble(-1));
        while (DatMonth < DatMonth2)
        {
            if (DatMonth.DayOfWeek == System.DayOfWeek.Sunday)
                lst.Add(DatMonth);
     
            DatMonth = DatMonth.AddDays(1);
        }
        return lst.ToArray();
    }
