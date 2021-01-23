    public static string Substring(string input)
    {
        if (!String.IsNullOrEmpty(input))
        {
            int lastIndex = input.LastIndexOf('.');
            if (lastIndex != -1)
                return input.Substring(lastIndex + 1);
        }
    
        return input;
    }
