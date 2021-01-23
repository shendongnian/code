    public event EventHandler SearchRequest;
    private delegate void OnSearchRequestDelegate(SynchronizationContext context);
    private void OnSearchRequest(SynchronizationContext context)
    {
        context.Send(state => SearchRequest(this, EventArgs.Empty), null);
    }
    public async Task SearchCommandAsync()
    {
        IsSearching = true;
        if (SearchRequest != null)
        {
            var search = new OnSearchRequestDelegate(OnSearchRequest);
            await Task.Factory.FromAsync(search.BeginInvoke, search.EndInvoke, SynchronizationContext.Current, null);
        }
        IsSearching = false;
    }
