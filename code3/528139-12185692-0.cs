    // I use this static method to make it faster.
    private static Regex oClearHtmlScript = new Regex(@"<(.|\n)*?>", RegexOptions.Compiled);
    
    public static string RemoveAllHTMLTags(string sHtml)
    {
        if (string.IsNullOrEmpty(sHtml))
             return string.Empty;
    
        return oClearHtmlScript.Replace(sHtml, string.Empty);
    }
