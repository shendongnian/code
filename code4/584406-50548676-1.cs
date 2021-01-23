    public static List<Cookie> List(this CookieContainer container)
    {
        var cookies = new List<Cookie>();
        var table = (Hashtable)container.GetType().InvokeMember("m_domainTable",
            BindingFlags.NonPublic |
            BindingFlags.GetField |
            BindingFlags.Instance,
            null,
            container,
            null);
        foreach (string key in table.Keys)
        {
            var item = table[key];
            var items = (ICollection) item.GetType().GetProperty("Values").GetGetMethod().Invoke(item, null);
            foreach (CookieCollection cc in items)
            {
                foreach (Cookie cookie in cc)
                {
                    cookies.Add(cookie);
                }
            }
        }
        return cookies;
    }           
