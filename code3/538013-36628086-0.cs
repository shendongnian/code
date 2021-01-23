    public event EventHandler SearchRequest;
    public async Task SearchCommandAsync()
    {
        IsSearching = true;
        if (SearchRequest != null)
        {
            await Task.Factory.FromAsync(SearchRequest.BeginInvoke, SearchRequest.EndInvoke, this, EventArgs.Empty, null);
        }
        IsSearching = false;
    }
