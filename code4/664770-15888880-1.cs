    public async Task<IEnumerable<WebResult>> SearchAsynch(string query)
    {
        DataServiceQuery<WebResult> webQuery = _bingContainer.Web(query, null, null, null, null, null, null, null);
        var results = await Task.Factory.FromAsync(webQuery.BeginExecute(null, null)
                , new Func<IAsyncResult, IEnumerable<WebResult>>(webQuery.EndExecute));
        Console.WriteLine("Hi there");
        return results;
    }
