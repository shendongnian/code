    // ----------------------------------------------------------------------
    public void GapFinder()
    {
      // base periods
      TimePeriodCollection basePeriods = new TimePeriodCollection();
      basePeriods.Add( new TimeRange( new DateTime( 2012, 1, 1 ), new DateTime( 2012, 1, 10 ) ) );
      basePeriods.Add( new TimeRange( new DateTime( 2012, 1, 11 ), new DateTime( 2012, 1, 25 ) ) );
      ITimePeriodCollection combinedBasePeriods = new TimePeriodCombiner<TimeRange>().CombinePeriods( basePeriods );
    
      // test periods
      TimePeriodCollection testPeriods = new TimePeriodCollection();
      testPeriods.Add( new TimeRange( new DateTime( 2012, 1, 2 ), new DateTime( 2012, 1, 7 ) ) );
      testPeriods.Add( new TimeRange( new DateTime( 2012, 1, 8 ), new DateTime( 2012, 1, 9 ) ) );
      testPeriods.Add( new TimeRange( new DateTime( 2012, 1, 15 ), new DateTime( 2012, 1, 30 ) ) );
      ITimePeriodCollection combinedTestPeriods = new TimePeriodCombiner<TimeRange>().CombinePeriods( testPeriods );
    
      // gaps
      TimePeriodCollection gaps = new TimePeriodCollection();
      foreach ( ITimePeriod basePeriod in combinedBasePeriods )
      {
        gaps.AddAll( new TimeGapCalculator<TimeRange>().GetGaps( combinedTestPeriods, basePeriod ) );
      }
      foreach ( ITimePeriod gap in gaps )
      {
        Console.WriteLine( "Gap: " + gap );
      }
    } // GapFinder
