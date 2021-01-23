    // ----------------------------------------------------------------------
    public void CheckAvailableTmeFrame()
    {
      TimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new TimeRange( new DateTime( 2013, 4, 20 ), new DateTime( 2013, 4, 24 ) ) );
      periods.Add( new TimeRange( new DateTime( 2013, 4, 16 ), new DateTime( 2013, 4, 24 ) ) );
      periods.Add( new TimeRange( new DateTime( 2013, 4, 20 ), new DateTime( 2013, 4, 28 ) ) );
      periods.Add( new TimeRange( new DateTime( 2013, 4, 16 ), new DateTime( 2013, 4, 26 ) ) );
    
      // test period
      TimeRange test = new TimeRange( new DateTime( 2013, 4, 18 ), new DateTime( 2013, 4, 25 ) );
    
      // find the available 
      TimeGapCalculator<TimeRange> gapCalculator = new TimeGapCalculator<TimeRange>();
       ITimePeriodCollection gaps = gapCalculator.GetGaps( periods, test );
      Console.WriteLine( "Time frame {0}. Available: {1}", 
         test, gaps.Count == 1 && gaps[ 0 ].Equals( test ) );
    } // CheckAvailableTmeFrame
