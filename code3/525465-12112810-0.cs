    public static bool TryFormat(string format, out string result, params Object[] args)
    {
       try
       {
          result = String.Format(format, args);
          return true;
       }
       catch(FormatException)
       {
          return false;
       }
    }
