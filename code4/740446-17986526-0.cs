      // true  - instance is correct
      // false - instance is incorrect
      // null  - additional info required
      public bool? Correct { get; set; }
      // true  - response was given 
      // false - no response
      // null  - say, the response is in the process
      public bool? Response { get; set; }
