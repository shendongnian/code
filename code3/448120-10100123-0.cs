    public static class TimeHelper {
       public static DateTime RoundDown (this DateTime time)
       {
           return time.AddMinutes(
             time.Minutes>30 ? -(time.Minutes-30) : -time.Minutes);
       }
    }
