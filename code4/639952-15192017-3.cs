    public async static Task<string> GetHttpResponse(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("UserAgent", "Windows 8 app client");
            
        var client = new HttpClient();
        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            
        if (response.StatusCode == HttpStatusCode.OK)
          return await response.Content.ReadAsStringAsync();
        else
         throw new Exception("Error connecting to " + url +" ! Status: " + response.StatusCode);
    }
