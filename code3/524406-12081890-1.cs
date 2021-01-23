    public static string EmptyToNumber(this string input)
    {
        return (string.IsNullOrEmpty(input) ? "0" : input); 
    }
   
