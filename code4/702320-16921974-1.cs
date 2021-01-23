    public DateTime Submitted {
      get {
        DateTime utcTime = DateTime.SpecifyKind(DateTime.Parse(/*"Your Stored val from DB"*/), DateTimeKind.Utc);
    
        return utcTime.ToLocalTime();
      }
    
      set {
        ...
      }
    }
