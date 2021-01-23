    public static string ReplaceWordChars(this string text)
    {
        var s = text;
        
        s = Regex.Replace(s, "[\u2018|\u2019|\u201A]", "'"); // smart single quotes and apostrophe
        s = Regex.Replace(s, "[\u201C|\u201D|\u201E]", "\""); // smart double quotes
        s = Regex.Replace(s, "\u2026", "..."); // ellipsis
        s = Regex.Replace(s, "[\u2013|\u2014]", "-"); // dashes
        s = Regex.Replace(s, "\u02C6", "^"); // circumflex
        s = Regex.Replace(s, "\u2039", "<"); // open angle bracket
        s = Regex.Replace(s, "\u203A", ">"); // close angle bracket
        s = Regex.Replace(s, "[\u02DC|\u00A0]", " "); // spaces
        
        return s;
    }
