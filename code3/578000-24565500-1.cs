    private static void Download(string url, ConcurrentDictionary<string, string> htmlDictionary)
    {
        using (var webClient = new SmartWebClient())
        {
            htmlDictionary.TryAdd(url, webClient.DownloadString(url));
        }
    }
