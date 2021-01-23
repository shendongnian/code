    // ----------------------------------------------------------------------
    public void TimeRangeSample()
    {
      // --- time range 1 ---
      TimeRange timeRange1 = new TimeRange(
        new DateTime( 2011, 2, 22, 14, 0, 0 ),
        new DateTime( 2011, 2, 22, 18, 0, 0 ) );
      Console.WriteLine( "TimeRange1: " + timeRange1 );
      // > TimeRange1: 22.02.2011 14:00:00 - 18:00:00 | 04:00:00
    
      // --- time range 2 ---
      TimeRange timeRange2 = new TimeRange(
        new DateTime( 2011, 2, 22, 15, 0, 0 ),
        new TimeSpan( 2, 0, 0 ) );
      Console.WriteLine( "TimeRange2: " + timeRange2 );
      // > TimeRange2: 22.02.2011 15:00:00 - 17:00:00 | 02:00:00
    
      // --- time range 3 ---
      TimeRange timeRange3 = new TimeRange(
        new DateTime( 2011, 2, 22, 16, 0, 0 ),
        new DateTime( 2011, 2, 22, 21, 0, 0 ) );
      Console.WriteLine( "TimeRange3: " + timeRange3 );
      // > TimeRange3: 22.02.2011 16:00:00 - 21:00:00 | 05:00:00
    
      // --- relation ---
      Console.WriteLine( "TimeRange1.GetRelation( TimeRange2 ): " +
                         timeRange1.GetRelation( timeRange2 ) );
      // > TimeRange1.GetRelation( TimeRange2 ): Enclosing
      Console.WriteLine( "TimeRange1.GetRelation( TimeRange3 ): " +
                         timeRange1.GetRelation( timeRange3 ) );
      // > TimeRange1.GetRelation( TimeRange3 ): EndInside
      Console.WriteLine( "TimeRange3.GetRelation( TimeRange2 ): " +
                         timeRange3.GetRelation( timeRange2 ) );
      // > TimeRange3.GetRelation( TimeRange2 ): StartInside
    
      // --- intersection ---
      Console.WriteLine( "TimeRange1.GetIntersection( TimeRange2 ): " +
                         timeRange1.GetIntersection( timeRange2 ) );
      // > TimeRange1.GetIntersection( TimeRange2 ):
      //             22.02.2011 15:00:00 - 17:00:00 | 02:00:00
      Console.WriteLine( "TimeRange1.GetIntersection( TimeRange3 ): " +
                         timeRange1.GetIntersection( timeRange3 ) );
      // > TimeRange1.GetIntersection( TimeRange3 ):
      //             22.02.2011 16:00:00 - 18:00:00 | 02:00:00
      Console.WriteLine( "TimeRange3.GetIntersection( TimeRange2 ): " +
                         timeRange3.GetIntersection( timeRange2 ) );
      // > TimeRange3.GetIntersection( TimeRange2 ):
      //             22.02.2011 16:00:00 - 17:00:00 | 01:00:00
    } // TimeRangeSample
