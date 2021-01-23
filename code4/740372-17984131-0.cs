    public Initialize()
    {
        HttpClientHandler = new HttpClientHandler
                                {
                                    AllowAutoRedirect = true,
                                    UseCookies = true,
                                    CookieContainer = new CookieContainer()
                                };
        HttpClient = new HttpClient(HttpClientHandler);
    }
    public CookieContainer Cookies
    {
        get { return HttpClientHandler.CookieContainer; }
        set { HttpClientHandler.CookieContainer = value; }
    }
