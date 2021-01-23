    public async static Task<string> GetHttpResponse(string url)
    {
        HttpClient client = new HttpClient();
        return await client.GetStringAsync(url);
    }
