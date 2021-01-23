    // <summary>
    /// Remove HTML from string with Regex.
    /// </summary>
    public static string StripTagsRegex(string source)
    {
       return Regex.Replace(source, "<.*?>", string.Empty);
    }
