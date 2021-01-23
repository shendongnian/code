    // ----------------------------------------------------------------------
    public DateTime? GetDayOfLastQuarterMonth( DayOfWeek dayOfWeek, int count )
    {
      Quarter quarter = new Quarter();
      Month lastMonthOfQuarter = new Month( quarter.End.Date );
    
      DateTime? searchDay = null;
      foreach ( Day day in lastMonthOfQuarter.GetDays() )
      {
        if ( day.DayOfWeek == dayOfWeek )
        {
          count--;
          if ( count == 0 )
          {
            searchDay = day.Start.Date;
            break;
          }
        }
      }
      return searchDay;
    } // GetDayOfLastQuarterMonth
