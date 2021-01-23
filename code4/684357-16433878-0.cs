    // ----------------------------------------------------------------------
    public void CalcMonths( DateTime epoch )
    {
      DateDiff dateDiff = new DateDiff( DateTime.Now, epoch );
      Console.WriteLine( "{0} months", dateDiff.Months );
      // > 1 Year 4 Months 12 Days 12 Hours ago
    } // CalcMonths
