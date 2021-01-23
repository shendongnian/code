    public string DowloadSomeData(int pages)
    {
        string someInformation = string.Empty;
        CookieContainer cookie = this._web.Cookie;
        Parallel.For(0, pages, i =>
        {
            // pass in the auth'ed cookie
            var web = new CookieAwareWebClient(cookie);
            html = web.DownloadString("http://example.com/");
            someInformation += this.GetSomeInformation(html)
        });
        return someInformation;
    }
