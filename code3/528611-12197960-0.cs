    // ----------------------------------------------------------------------
    public void CalendarWeekSample()
    {
      DateTime testDate = new DateTime( 2007, 12, 31 );
    
      // .NET calendar week
      TimeCalendar calendar = new TimeCalendar();
      Console.WriteLine( "Calendar Week of {0}: {1}", testDate.ToShortDateString(),
                         new Week( testDate, calendar ).WeekOfYear );
      // > Calendar Week of 31.12.2007: 53
    
      // ISO 8601 calendar week
      TimeCalendar calendarIso8601 = new TimeCalendar(
        new TimeCalendarConfig { YearWeekType = YearWeekType.Iso8601 } );
      Console.WriteLine( "ISO 8601 Week of {0}: {1}", testDate.ToShortDateString(),
                         new Week( testDate, calendarIso8601 ).WeekOfYear );
      // > ISO 8601 Week of 31.12.2007: 1
    } // CalendarWeekSample
