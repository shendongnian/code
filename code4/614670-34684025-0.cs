    private static readonly Random random = new Random ();
    private static readonly object syncLock = new object ();
    public static DateTime RandomDate(DateTime from, DateTime to)
    {
        lock ( syncLock )
        {
             return from.AddTicks ((long) ( random.NextDouble () * ( to.Ticks - from.Ticks ) ));
        }
     }
