    public void ProcessRequest(HttpContext context)
    {
        if (string.IsNullOrEmpty(context.Request.QueryString[_QUERY_PARAM]))
            throw new Exception(string.Format("Could not find parameter '{0}'", _QUERY_PARAM));
        // Get the suggestion word from the parameter
        string term = context.Request.QueryString[_QUERY_PARAM];
        // Create an URL to the GSA
        string suggestionUrl = SuggestionUrl(term);
        // Call the GSA and get the GSA result as a string
        string page = GetPageAsString(suggestionUrl);
        context.Response.Write(page);
        //Should inform about the content type to client
        context.Response.ContentType = "application/json";
        context.Response.End();
    }
