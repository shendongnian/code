    // ----------------------------------------------------------------------
    public void CheckDayOfLastQuarterMonth()
    {
      DateTime? day = GetDayOfLastQuarterMonth( DayOfWeek.Friday, 3 );
      if ( day.HasValue && day.Equals( DateTime.Now.Date ) )
      {
        // do ...
      }
    } // CheckDayOfLastQuarterMonth
