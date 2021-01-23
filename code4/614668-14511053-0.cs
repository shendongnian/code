    static readonly Random rnd = new Random();
    public static DateTime GetRandomDate(DateTime from, DateTime to)
    {
        var range = to - from;
        var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks)); 
        return from + randTimeSpan;
    }
