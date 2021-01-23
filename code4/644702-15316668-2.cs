	public Task<Args> SomeApiWrapper()
	{
		TaskCompletionSource<Args> tcs = new TaskCompletionSource<Args>(); 
		
		var obj = new SomeApi();
		
		// will get raised, when the work is done
		obj.Done += (args) => 
		{
			// this will notify the caller 
			// of the SomeApiWrapper that 
			// the task just completed
			tcs.SetResult(args);
		}
		
		// start the work
		obj.Do();
		
		return tcs.Task;
	}
