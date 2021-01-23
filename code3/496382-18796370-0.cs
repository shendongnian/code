    private static DateTime RoundDown(DateTime dateTime, TimeSpan interval)
    {
      return dateTime.AddTicks(-(dateTime.Ticks % interval.Ticks));
    }
    private static DateTime RoundUp(DateTime dateTime, TimeSpan interval)
    {
      return dateTime.AddTicks(interval.Ticks - (dateTime.Ticks % interval.Ticks));
    }
