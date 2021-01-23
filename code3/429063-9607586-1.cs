    static class HumanAgeFactory
    {
      
      public static HumanAge ComputeAge( this DateTime dob )
      {
        return dob.ComputeAgeAsOf( DateTime.Now ) ;
      }
      
      public static HumanAge ComputeAgeAsOf( this DateTime dob , DateTime now )
      {
        dob = dob.Date ; // toss the time component
        now = now.Date ; // toss the time component
        
        if ( dob > now ) throw new ArgumentOutOfRangeException( "dob" , "'now' must be on or after 'dob'" ) ;
        
        DateTime mostRecentBirthDay = MostRecentNthDayOfTheMonthOnOrBefore( dob.Day , now ) ;
        int      years              = mostRecentBirthDay.Year  - dob.Year          ;
        int      months             = mostRecentBirthDay.Month - dob.Month         ;
        int      days               = (int) ( now - mostRecentBirthDay ).TotalDays ;
        
        if ( months < 0 )
        {
          months += 12 ;
          years  -=  1 ;
        }
        
        if ( days   < 0 ) throw new InvalidOperationException() ;
        if ( months < 0 ) throw new InvalidOperationException() ;
        if ( years  < 0 ) throw new InvalidOperationException() ;
        
        HumanAge instance = new HumanAge( years , months , days ) ;
        return instance ;
      }
      
      private static DateTime MostRecentNthDayOfTheMonthOnOrBefore( int nthDay , DateTime now )
      {
        if ( nthDay < 1 ) throw new ArgumentOutOfRangeException( "dayOfBirth" ) ;
        
        int year  = now.Year  ;
        int month = now.Month ;
        
        if ( nthDay > now.Day )
        {
          --month ;
          if ( month < 1 )
          {
            month += 12 ;
            year  -=  1 ;
          }
        }
        
        int daysInMonth = CultureInfo.CurrentCulture.Calendar.GetDaysInMonth( year , month ) ;
        int day         = ( nthDay > daysInMonth ? daysInMonth : nthDay ) ;
        
        DateTime instance = new DateTime( year , month , day ) ;
        return instance ;
      }
      
    }
    
    public class HumanAge
    {
      public int Years  { get ; private set ; }
      public int Months { get ; private set ; }
      public int Days   { get ; private set ; }
      
      public override string ToString()
      {
        string instance = string.Format( "{0} {1} , {2} {3} , {4} {5}" ,
          Years  , Years  == 1 ? "year"  : "years"  ,
          Months , Months == 1 ? "month" : "months" ,
          Days   , Days   == 1 ? "day"   : "days"
          ) ;
        return instance ;
      }
      
      public HumanAge( int years , int months , int days )
      {
        if ( years  < 0                ) throw new ArgumentOutOfRangeException( "years"  ) ;
        if ( months < 0 || months > 12 ) throw new ArgumentOutOfRangeException( "months" ) ;
        if ( days   < 0 || days   > 31 ) throw new ArgumentOutOfRangeException( "days"   ) ;
        
        this.Years  = years  ;
        this.Months = months ;
        this.Days   = days   ;
        
        return ;
      }
      
    }
