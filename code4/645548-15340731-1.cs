    async Task<List<object>> getCategories(String uri)
    {
        var taskCompletionObj = new TaskCompletionSource<string>();
        var wc= new webClient();
        wc.DownloadStringAsync(new URI(uri, Urikind.Absolute)) += (o, e) =>
        {
        taskCompletionObj.TrySetResult(e.Result);
        };
        string rawString = await taskCompletionObj.Task;
        RootObject r = JsonConvert.DeserializeObject<RootObject>(rawString);
        return r.Result; 
    }
