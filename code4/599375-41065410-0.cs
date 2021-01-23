	public static Task<LoginCompletedEventArgs> RaiseInvoiceAsync(this Client client, string userName, string password)
	{
		var tcs = CreateSource<LoginCompletedEventArgs>();
		LoginCompletedEventHandler handler = null;
		handler = (sender, e) => TransferCompletion(tcs, e, () => e, () => client.LoginCompleted -= handler);
		client.LoginCompleted += handler;
		try
		{
			client.LoginAsync(userName, password, tcs);
		}
		catch
		{
			client.LoginCompleted -= handler;
			tcs.TrySetCanceled();
			throw;
		}
		return tcs.Task;
	}
