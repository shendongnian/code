    public static class Validator {   
      public static bool IsValid(string item) {
        int value;
        return int.TryParse(item, out value) 
               && value > 0 && value < 1000;    
      } 
    }
