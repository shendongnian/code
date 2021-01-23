    string url1 = "http://www.gmail.com?a=1&cookie=cookieValue"
    RemoveQueryStringByKey(ref url1,"cookie"); //OUTPUT: "http://www.gmail.com?a=1"
    string url2 = "http://www.gmail.com?cookie=cookieValue"  
    RemoveQueryStringByKey(ref url2,"cookie"); //OUTPUT: "http://www.gmail.com"
    public static void RemoveQueryStringByKey(ref string url, string key)
    {
        if (string.IsNullOrEmpty(url) ||
            string.IsNullOrEmpty(key) ||
            Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) == false)
        {
            return;
        }            
        try
        {
            Uri uri = new Uri(url);
            // This gets all the query string key value pairs as a collection
            NameValueCollection queryCollection = HttpUtility.ParseQueryString(uri.Query);
            string keyValue = queryCollection.Get(key);
            if (string.IsNullOrEmpty(keyValue))
            {
                return;
            }
            url = url.Replace("&" + key + "=" + keyValue, String.Empty);
            url = url.Replace("?" + key + "=" + keyValue, String.Empty);
        }
        catch
        {
            return;
        }
    }
