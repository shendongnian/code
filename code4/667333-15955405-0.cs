    public static IEnumerable<int> WeekNumbersBetween(
       DateTime startDate, 
       DateTime endDate, 
       Calendar calendar = null,
       CalendarWeekRule weekRule = CalendarWeekRule.FirstDay,
       DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
    {
       if (calendar == null)
       {
          calendar = new GregorianCalendar();
       }
       
       DateTime week = startDate;
       while (week <= endDate)
       {
          yield return calendar.GetWeekOfYear(week, weekRule, firstDayOfWeek);
          week = week.AddDays(7);
       }
    }
