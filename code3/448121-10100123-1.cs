    public static class TimeHelper {
       public static DateTime RoundDown (this DateTime time)
       {
           return time.AddMinutes(
             time.Minute>30 ? -(time.Minute-30) : -time.Minute);
       }
    }
