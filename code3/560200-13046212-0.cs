    public static async Task<int> GetPageLength(string url)
    {
        string text = await new WebClient().DownloadStringTaskAsync(url);
        return text.Length;
    }
