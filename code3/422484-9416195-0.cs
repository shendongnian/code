    // ----------------------------------------------------------------------
    public void CalendarDateAddSample()
    {
      CalendarDateAdd calendarDateAdd = new CalendarDateAdd();
      // use only weekdays
      calendarDateAdd.AddWorkingWeekDays();
      // setup working hours
      calendarDateAdd.WorkingHours.Add( new HourRange( new Time( 09 ), new Time( 17 ) ) );
    
      DateTime start = new DateTime( 2012, 2, 23 ); // start date
      TimeSpan offset = new TimeSpan( 4, 0, 0 ); // 4 hours
    
      DateTime? end = calendarDateAdd.Add( start, offset ); // end date
    
      Console.WriteLine( "start: {0}", start );
      Console.WriteLine( "offset: {0}", offset );
      Console.WriteLine( "end: {0}", end );
    } // CalendarDateAddSample
