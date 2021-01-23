    public static class DateTimeExtensions
    {
       public static DateTime ZeroMilliseconds(this DateTime dt)
       {
          return new DateTime(((dt.Ticks / 10000000) * 10000000), dt.Kind);
       }
    }
