     public Task<string> GetPageData(string link)
            {
                _request = new HttpRequestMessage(HttpMethod.Get, link);
                _request.Headers.Add("User-Agent", "Chrome/21.0.1180.89");
                _request.Headers.Add("Accept", "text/html");
    
    
                return _client.GetStringAsync(link);
            }
