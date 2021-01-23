    // ----------------------------------------------------------------------
    public void QuarterStartEndMonth()
    {
      DateTime now = DateTime.Now;
    
      Quarter pastQuarter = GetQuarter( new DateTime( now.Year - 1, 10, 1 ) );
      Console.WriteLine( "Quarter last month {0:d}", pastQuarter.LastMonthStart );
      Console.WriteLine( "Next quarter start month {0:d}",
        pastQuarter.GetNextQuarter().Start );
    
      Quarter futureQuarter = GetQuarter( new DateTime( now.Year + 1, 10, 1 ) );
      Console.WriteLine( "Quarter last month {0:d}", futureQuarter.LastMonthStart );
      Console.WriteLine( "Next quarter start month {0:d}",
        futureQuarter.GetNextQuarter().Start );
    } // QuarterStartEndMonth
    
    // ----------------------------------------------------------------------
    private Quarter GetQuarter( DateTime moment )
    {
      DateTime now = DateTime.Now;
      return new Quarter( now > moment ? now : moment );
    } // GetQuarter
