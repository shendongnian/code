    class Person { 
      public bool IsAthlete { get; private set; } 
      public bool IsSoccerPlayer { get; private set; } 
      public bool IsTennisPlayer { get; private set; }
      public static readonly TennisPlayer = new Person { 
        IsTennisPlayer = true, 
        IsAthelete = true
      }
      public static readonly SoccerPlayer = new Person { 
        IsSoccerPlayer = true, 
        IsAthelete = true
      }      
    }
  
  
 
