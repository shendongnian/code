    public Task<DataObject> GetDataAsync()
    {
        var client = new WebClient();
        return client.DownloadStringTaskAsync(_url)
                     .ContinueWith((Func<Task<string>, DataObject>)ExtractData);
    }
    private DataObject ExtractData(Task<string> task)
    {
        return new DataObject(task.Result);
    }
