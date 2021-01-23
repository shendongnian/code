    public static DateTime RoundDown(this DateTime time)
    {
        return time.Subtract(
            new TimeSpan(0, 0, time.Minute > 30 ? (time.Minute - 30) : time.Minute, 
                time.Second, time.Millisecond));
    }
