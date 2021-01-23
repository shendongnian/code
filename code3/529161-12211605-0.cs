    // ----------------------------------------------------------------------
    public bool CheckDateBetweenDatesSample()
    {
      DateTime now = DateTime.Now;
      TimePeriodCollection periods = new TimePeriodCollection();
      // read periods (Start/end) from database
      // ...
      periods.Add( new TimeRange( start, end ) );
      return periods.HasIntersectionPeriods( now );
    } // CheckDateBetweenDatesSample
