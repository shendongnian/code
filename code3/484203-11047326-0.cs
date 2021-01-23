    public static class Extension
    {
        public static string ReplaceMiddle(this string value, char charToPutIn)
        {
            var builder = new StringBuilder(value);
    	    builder[value.Length/2] = charToPutIn;
    	    return builder.ToString();
        }
    
    }
