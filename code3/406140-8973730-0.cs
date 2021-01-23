    public static class Ex
    {
      public static string ToSpecialString(this string value)
      {
        int desiredLength = 10;
        string prefix = "01";
        string padding = new String('0', desiredLength - prefix.Length - value.Length);
        return prefix + padding + value;
      }
    }
    
    ... usage ...
    
    Console.WriteLine( "32".ToSpecialString() );
    // should output "0100000032"
