    public string GetFullHtmlFieldName(string partialFieldName)
    {
        /*Here's the extra dot: causing the error.*/
        return (this.HtmlFieldPrefix + "." + (partialFieldName ?? string.Empty)).Trim(new char[] { '.' });
    }
