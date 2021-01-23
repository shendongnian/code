    public static class Extensions
    {
      public static String Format(this String str, 
                                  String formatText, 
                                  params object[] args)
      {
        return str.Format(formatText, args);
      }
    }
    
