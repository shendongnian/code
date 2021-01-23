    class Company
    {
      public string   Name         { get ; set ; }
      
      // represents the time-of-day at which the company opens (e.g. 08:00, 14:00, etc.)
      public TimeSpan OpensAtTime  { get ; set ; }
      
      // represents the time-of-day at which the company closes (e.g.17:00, 08:00, etc. )
      public TimeSpan ClosesAtTime { get ; set ; }
      
      public bool IsOpen()
      {
        DateTime instant          = DateTime.Now ;
        DateTime Today            = instant.Date ;
        TimeSpan totalOpenHours   = ( this.ClosesAtTime - this.OpensAtTime ).Duration() ;
        DateTime openTimeToday    = Today + this.OpensAtTime ;
        DateTime closingTimeToday = openTimeToday + totalOpenHours ;
        bool     isOpen           = instant >= openTime && instant <= closingTime ;
        
        return isOpen ;
      }
      
    }
