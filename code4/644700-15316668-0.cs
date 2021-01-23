	public Task<Args> SomeApiWrapper()
	{
		TaskCompletionSource<Args> tcs = new TaskCompletionSource<Args>(); 
		
		var obj = new SomeApi();
		obj.Done += (args) => 
		{
			tcs.SetResult(args);
		}
		obj.Do();
		
		return tcs.Task;
	}
