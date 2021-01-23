    public static class DateTimeExtensions
    {
      public static bool IsWeekday(this DateTime dt)
      {
       return dt.DayOfWeek != DayOfWeek.Sunday && dt.DayOfWeek != DayOfWeek.Saturday;
      }
    }
