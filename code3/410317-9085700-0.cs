    public Task<bool> AskConfirmation()
    {
    	var tcs = new TaskCompletionSource<bool>();
    	AskConfirmation(b => tcs.TrySetResult(b));
    	return tcs.Task;
    }
