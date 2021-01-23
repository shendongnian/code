    var queryParams = new Dictionary<string, string>(
        HtmlPage.Document.QueryString,
        StringComparer.CurrentCultureIgnoreCase
    );
    if (queryParams.ContainsKey("territory")) {
        // Covers "territory", "Territory", "teRRitory", etc.
    }
   
