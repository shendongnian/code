    public static class Validation
    {
      private static Regex dateRegex = new Regex("^\\d{2}/\\d{2}/\\d{4}$");
      public static boolean Validate(string type, string stringToValdate)
      {
        boolean valid = false;
        if (type = "date")
        {
            Match m = dateRegex.Match(stringToValdate);
            if(m.Success)
            {
              valid = true;
            }
        }
    
       return valid;
      }
    }
