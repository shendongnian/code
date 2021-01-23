    public static string ToDigitsOnly(this string input)
    {
        if(input == null)
              throw new ArgumentNullException("input");
    
        Regex digitsOnly = new Regex(@"[^\d]");
        return digitsOnly.Replace(input, String.Empty);
    }
