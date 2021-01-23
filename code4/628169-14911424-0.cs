    public static class DateTimeExtensions
    {
      internal static readonly long DatetimeMinTimeTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
        
      public static long ToJsTime(this DateTime dateTime)
      {
        return (dateTime.ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000L;
      }
    }
