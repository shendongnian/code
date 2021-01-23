    public async static Task<string> GetHttpResponse(string url)
    {
        var client = new HttpClient();
        return await client.GetStringAsync(url);
    }
