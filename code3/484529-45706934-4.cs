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
            if (url.IndexOf("&" + key + "=" + keyValue, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                url = url.Replace("&" + key + "=" + keyValue, String.Empty);
                return true;
            }
            else if (url.IndexOf("?" + key + "=" + keyValue, StringComparison.OrdinalIgnoreCase) >= 0)
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
