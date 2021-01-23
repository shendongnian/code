    public static decimal ParseDecimalNumber( string s , string groupSeparators , string decimalPoints )
    {
      NumberFormatInfo nfi   = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone() ;
      NumberStyles     style = NumberStyles.AllowLeadingWhite
                             | NumberStyles.AllowLeadingSign
                             | NumberStyles.AllowThousands
                             | NumberStyles.AllowDecimalPoint
                             | NumberStyles.AllowTrailingSign
                             | NumberStyles.AllowTrailingWhite
                             ;
      decimal          value ;
      bool             parsed = false ;
      
      for ( int i = 0 ; !parsed && i < groupSeparators.Length ; ++i )
      {
          
        nfi.NumberGroupSeparator = groupSeparators.Substring(i,1) ;
        
        for ( int j = 0 ; !parsed && j < decimalPoints.Length ; ++j )
        {
          if ( groupSeparators[i] == decimalPoints[j] ) continue ; // skip when group and decimal separator are identical
          
          nfi.NumberDecimalSeparator = decimalPoints.Substring(j,1) ;
          
          parsed = Decimal.TryParse( s , style , nfi , out value ) ;
          
        }
      }
      
      if ( !parsed ) throw new ArgumentOutOfRangeException("s") ;
      
      return value ;
      
    }
