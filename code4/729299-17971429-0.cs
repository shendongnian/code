    // ----------------------------------------------------------------------
    public void FiscalYearRange()
    {
      // calendar
      TimeCalendar fiscalYearCalendar = new TimeCalendar(
        new TimeCalendarConfig
          {
            YearBaseMonth = YearMonth.April,
            YearType = YearType.FiscalYear
          } );
    
      // time range
      TimeRange timeRange = new TimeRange( new DateTime( 2007, 10, 1 ), new DateTime( 2012, 2, 25 ) );
      Console.WriteLine( "Time range: " + timeRange );
      Console.WriteLine();
    
      // fiscal quarter
      Console.WriteLine( "Start Quarter: " + new Quarter( timeRange.Start, fiscalYearCalendar ) );
      Console.WriteLine( "End Quarter: " + new Quarter( timeRange.End, fiscalYearCalendar ) );
      Console.WriteLine();
    
      // fiscal year
      Year year = new Year( timeRange.Start, fiscalYearCalendar );
      while ( year.Start < timeRange.End )
      {
        Console.WriteLine( "Fiscal Year: " + year );
        year = year.GetNextYear();
      }
    } // FiscalYearRange
