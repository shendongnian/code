    private byte[] GetTile(string url)
    {
        using (WebClient wc = new WebClient())
        {
            return wc.DownloadData(url);
        }
    }
