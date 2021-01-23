    public async Task<DataObject> GetDataAsync()
    {
        var client = new WebClient();
        var s = await client.DownloadStringTaskAsync(_url);
        return ExtractData(s);
    }
    private DataObject ExtractData(string s)
    {
        return new DataObject(s);
    }
