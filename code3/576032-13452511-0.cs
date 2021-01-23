    public static DateTime GetAddTimespan(string span)
    {
        var tokens = span.Split(':');
        TimeSpan ts = new TimeSpan(
                      int.Parse(tokens[0]),    // hours
                      int.Parse(tokens[1]),    // minutes
                      int.Parse(tokens[2]));   // seconds)                              
        return DateTime.Today + ts;
    }
