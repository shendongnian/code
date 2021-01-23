    public static string LastFour(this string value)
    {
        if (string.IsNullOrEmpty(value) || value.length < 4)
        {
            return "0000";
        }
        return value.Substring(value.Length - 4, 4) 
    }
