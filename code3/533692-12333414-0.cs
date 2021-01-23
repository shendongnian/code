    public static class Extension
    { 
        public static boolean Validate(this Master master string type, string stringToValdate)
        {
          boolean valid = NO;
          if (type = "date")
          {
              Match m = fechaRegex.Match(stringToValdate);
              if(m.Success)
              {
                    valid = true;
              }
          }
        
         return valid;
        }
    
    }
