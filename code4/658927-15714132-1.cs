    public static String ReplaceEnd(this string input, string subStr, string replace = "")
    {
        //Per Alexei Levenkov's comments, the string should
        // be escaped in order to avoid accidental injection
        // of special characters into the Regex pattern
        var escaped = Regex.Escape(subStr);
        var pattern = String.Format("({0})$", escaped);
        return Regex.Replace(input, pattern, replace);
    } 
