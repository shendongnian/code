    public void byte[] Load(string fileName)
    {
        Uri uri = new Uri(fileName);
        var client = new WebClient();
        return client.DownloadData(uri);
    }
