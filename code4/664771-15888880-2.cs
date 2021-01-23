    public Task<IEnumerable<WebResult>> SearchAsynch(string query)
    {
        DataServiceQuery<WebResult> webQuery = _bingContainer.Web(query, null, null, null, null, null, null, null);
        return Task.Factory.FromAsync(webQuery.BeginExecute(null, null)
            , asyncResult => webQuery.EndExecute(asyncResult)));
    }
