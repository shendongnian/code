    static class ToStringHelper
    {
      // We can use Generic method to prevent boxing
      public string ConvertToString(object o)
      {
        var sb = new StringBuilder();
        // using reflection to access all public properties, for example
    
        return sb.ToString();
      }
    }
