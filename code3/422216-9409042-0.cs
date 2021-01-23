    private static CookieContainer cookies;
    public static string Post(string url, string data)
    {
       string vystup = null;
       try
       {
           //SNIP other bits of setup
           if(cookies==null)
           {
              cookies = new CookieContainer();
           }
           WebReq.CookieContainer = cookies;
