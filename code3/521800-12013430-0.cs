    protected static string AssembleArgumentString(Dictionary<string, string> @params,   bool urlEncode)
    {
        if (urlEncode)
        {
            return string.Join("&", (from kv in @params where !string.IsNullOrEmpty(kv.Value)
                                     select kv.Key + "=" + System.Web.HttpUtility.UrlEncode(kv.Value)));
        }
        else
        {
            return string.Join("&", (from kv in @params where !string.IsNullOrEmpty(kv.Value)
                                     select kv.Key + "=" + kv.Value));
        } 
    }
