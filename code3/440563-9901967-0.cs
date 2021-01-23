    // ----------------------------------------------------------------------
    public bool IsInCurrentWeek( DateTime test )
    {
      return new Week().HasInside( test );
    } // IsInCurrentWeek
