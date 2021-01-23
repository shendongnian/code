    // ----------------------------------------------------------------------
    public void TimeSpansWithoutOverlap()
    {
      // periods
      ITimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new TimeRange( 
        new DateTime( 2013, 7, 1, 0, 0, 0 ), 
        new DateTime( 2013, 7, 1, 12, 0, 0 ) ) );
      periods.Add( new TimeRange( 
        new DateTime( 2013, 7, 1, 6, 0, 0 ),
        new DateTime( 2013, 7, 1, 18, 0, 0 ) ) );
    
      ITimePeriodCollection combinedPeriods = new TimePeriodCombiner<TimeRange>().CombinePeriods( periods );
      foreach ( ITimePeriod combinedPeriod in combinedPeriods )
      {
        Console.WriteLine( "Period: " + combinedPeriod );
      }
    } // TimeSpansWithoutOverlap
