    String DecodedUrl = HttpUtility.HtmlDecode(YourUrl);
    NameValueCollection UrlParameters = HttpUtility.ParseQueryString(DecodedUrl);
    if (UrlParameters.AllKeys.Contains("SOMETHING")) {
        // do something
    }
