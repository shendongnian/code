    enum Duration { Day, Week, Month };
    
    static class DurationExtensions 
    {
      public static DateTime From(this Duration duration, DateTime dateTime) 
      {
        switch (duration) 
        {
          case Day:   return dateTime.AddDays(1);
          case Week:  return dateTime.AddDays(7);
          case Month: return dateTime.AddMonths(1);
          default:    throw new ArgumentOutOfRangeException("duration");
        }
      }
    }
