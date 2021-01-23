    // ----------------------------------------------------------------------
    public void InvolvedWeekCount()
    {
      Console.WriteLine( "Involved week count: " +
        CalcInvolvedWeekCount( new DateTime( 2011, 1, 1 ), new DateTime( 2011, 1, 2 ), DayOfWeek.Sunday ) );
      // > Involved week count: 2
      Console.WriteLine( "Involved week count: " +
        CalcInvolvedWeekCount( new DateTime( 2011, 1, 2 ), new DateTime( 2011, 1, 8 ), DayOfWeek.Sunday ) );
      // > Involved week count: 1
      Console.WriteLine( "Involved week count: " +
        CalcInvolvedWeekCount( new DateTime( 2011, 1, 1 ), new DateTime( 2011, 1, 29 ), DayOfWeek.Sunday ) );
      // > Involved week count: 5
      Console.WriteLine( "Involved week count: " +
        CalcInvolvedWeekCount( new DateTime( 2011, 1, 1 ), new DateTime( 2011, 1, 30 ), DayOfWeek.Sunday ) );
      // > Involved week count: 6
      Console.WriteLine( "Involved week count: " +
        CalcInvolvedWeekCount( new DateTime( 2011, 1, 1 ), new DateTime( 2011, 2, 1 ), DayOfWeek.Sunday ) );
      // > Involved week count: 6
    } // InvolvedWeekCount
    
    // ----------------------------------------------------------------------
    private int CalcInvolvedWeekCount( DateTime date1, DateTime date2, DayOfWeek firstDayOfWeek )
    {
      if ( date1.Date.Equals( date2.Date ) )
      {
        return 0;
      }
    
      DateTime startWeek = TimeTool.GetStartOfWeek( date1, firstDayOfWeek );
      DateTime endWeek = TimeTool.GetStartOfWeek( date2, firstDayOfWeek ).AddDays( TimeSpec.DaysPerWeek );
    
      return (int)( endWeek.Subtract( startWeek ).TotalDays / TimeSpec.DaysPerWeek );
    } // CalcInvolvedWeekCount
