    private async Task<string> GetCookieValue(string url, string cookieName)
    {
        var cookieContainer = new CookieContainer();
        var uri = new Uri(url);
        using (var httpClientHandler = new HttpClientHandler
        {
            CookieContainer = cookieContainer
        })
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                await httpClient.GetAsync(uri);
                var cookie = cookieContainer.GetCookies(uri).Cast<Cookie>().FirstOrDefault(x => x.Name == cookieName);
                return cookie?.Value;
            }
        }
    }
