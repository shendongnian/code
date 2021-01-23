    string url1 = "http://www.gmail.com?a=1&cookie=cookieValue"
    Assert.IsTrue(TryRemoveQueryStringByKey(ref url1,"cookie")); //OUTPUT: "http://www.gmail.com?a=1"
    string url2 = "http://www.gmail.com?cookie=cookieValue"  
    Assert.IsTrue(TryRemoveQueryStringByKey(ref url2,"cookie")); //OUTPUT: "http://www.gmail.com"
    public static void TryRemoveQueryStringByKey(ref string url, string key)
    {
        if (string.IsNullOrEmpty(url) ||
            string.IsNullOrEmpty(key) ||
            Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) == false)
        {
            return false;
        }            
        try
        {
            Uri uri = new Uri(url);
            // This gets all the query string key value pairs as a collection
            NameValueCollection queryCollection = HttpUtility.ParseQueryString(uri.Query);
            string keyValue = queryCollection.Get(key);
            if (string.IsNullOrEmpty(keyValue))
            {
                return false;
            }
            if (url.Contains("&" + key + "=" + keyValue))
            {
                url = url.Replace("&" + key + "=" + keyValue, String.Empty);
                return true;
            }
            else if (url.Contains("?" + key + "=" + keyValue))
            {
                url = url.Replace("?" + key + "=" + keyValue, String.Empty);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
