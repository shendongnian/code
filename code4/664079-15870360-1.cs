    public async Task<string> DownloadString(string url)
    {
        WebClient client = new WebClient();
        return await client.DownloadStringTaskAsync(url);
    }
