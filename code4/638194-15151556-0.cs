    public static int GetWeekOfMonth(DateTime date)
    {
      var weekDay = date.DayOfWeek;
      var nth = date.Day / 7;
      if (date.Day % 7 > 0)
      {
        nth++;
      }
      return nth;
    }
