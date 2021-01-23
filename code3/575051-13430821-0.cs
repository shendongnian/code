	Task CreateAsync(CloudTable tbl, CancellationToken token)
	{
		ICancellableAsyncResult result = tbl.BeginCreate(null, null);
		var cancellationRegistration = token.Register(result.Cancel);
		return Task.Factory.FromAsync(result, ar =>
		{
			cancellationRegistration.Dispose();
			tbl.EndCreate(ar);
		});
	}
	Task<bool> ExistsAsync(CloudTable tbl, CancellationToken token)
	{
		ICancellableAsyncResult result = tbl.BeginExists(null, null);
		var cancellationRegistration = token.Register(result.Cancel);
		return Task.Factory.FromAsync(result, ar =>
		{
			cancellationRegistration.Dispose();
			return tbl.EndExists(ar);
		});
	}
