    private CookieCollection cookieCollection;
    
    ...
    
        parserObject = new HtmlWeb
                    {
                        AutoDetectEncoding = true,
                        PreRequest = request =>
                        {
                            if (cookieCollection != null)
                                cookieCollection.Cast<Cookie>()
                                    .ForEach(cookie => request.CookieContainer.Add(cookie));
                            return true;
                        },
                        PostResponse = (request, response) => { cookieCollection = response.Cookies; }
                    };
