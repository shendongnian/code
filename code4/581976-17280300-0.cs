    public async Task<string> DownloadHtmlCode(string url)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true, AllowAutoRedirect = true };
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = await client.GetAsync(url);                  
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
