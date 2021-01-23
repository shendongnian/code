    public string GetwebContent(string urlForGet)
    {
        // Create WebClient
        var client = new WebClient();
        // Download Text From web
        var text = client.DownloadString(urlForGet);
        return text.ToString();
    }
