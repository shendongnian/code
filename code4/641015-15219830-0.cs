    public async Task<JsonObject> GetAsync(string uri)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
     
        string content = await response.Content.ReadAsStringAsync();
        return await Task.Run(() => JsonObject.Parse(content));
    }
