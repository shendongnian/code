    private static readonly Regex simpleUrlPath = new Regex("^[-a-zA-Z0-9_/]*$", RegexOptions.Compiled);
    private static readonly char[] segmentsSplitChars = { '/' };
    // ^^^ avoids lots of gen-0 arrays being created when calling .Split
    public static Uri GetRealUrl(this HttpRequest request)
    {
        if (request == null) throw new ArgumentNullException("request");
        var baseUri = request.Url; // use this primarily to avoid needing to process the protocol / authority
        try
        {
            var vars = request.ServerVariables;
            var url = vars["URL"];
            if (string.IsNullOrEmpty(url) || simpleUrlPath.IsMatch(url)) return baseUri; // nothing to do - looks simple enough even for IIS
            var query = vars["QUERY_STRING"];
            // here's the thing: url contains *decoded* values; query contains *encoded* values
            // loop over the segments, encoding each separately
            var sb = new StringBuilder(url.Length * 2); // allow double to be pessimistic; we already expect trouble
            var segments = url.Split(segmentsSplitChars);
            foreach (var segment in segments)
            {
                if (segment.Length == 0)
                {
                    sb.Append('/');
                }
                else if (simpleUrlPath.IsMatch(segment))
                {
                    sb.Append('/').Append(segment);
                }
                else
                {
                    sb.Append('/').Append(HttpUtility.UrlEncode(segment));
                }
            }
            if (!string.IsNullOrEmpty(query)) sb.Append('?').Append(query); // query is fine; nothing needing
            return new Uri(baseUri, sb.ToString());
        }
        catch (Exception ex)
        { // if something unexpected happens, default to the broken ASP.NET handling
            GlobalApplication.LogException(ex);
            return baseUri;
        }
    }
