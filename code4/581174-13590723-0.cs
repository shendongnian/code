    private static Random rng = new Random();
    public IEnumerable<DateTime> RandomDateTimes( DateTime lowerBound , DateTime upperBound , int count )
    {
        TimeSpan period = upperBound - lowerBound ;
        if ( period <= TimeSpan.Zero || period > new TimeSpan(1,0,0,0) ) throw new ArgumentException();
        if ( count < 0 ) throw new ArgumentException() ;
        int rangeInMinutes = (int) period.TotalMinutes ; // period is 0 through 1440
        for ( int i = 0 ; i < count ; ++i )
        {
            int offset = rng.Next(rangeInMinutes) ;
            yield return lowerBound.AddMinutes(offset) ;
        }
    }
    public IEnumerable<DateTime> OrderedRandomDateTimes( DateTime lowerbound , DateTime upperBound , int count )
    {
        yield return RandomDateTimes( lowerbound , upperBound , count ).OrderBy( x = x ) ;
    }
