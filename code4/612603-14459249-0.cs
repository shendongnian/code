      public int movieYearInt 
      {
        get
        {
          // add some validation, and consider using System.Int32.TryParse
          return System.Int32.Parse(movieYear);
        }      
      }
