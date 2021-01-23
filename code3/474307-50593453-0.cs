	public static Task RunAsync(this Process process)
	{
		var tcs = new TaskCompletionSource<object>();
		process.EnableRaisingEvents = true;
		process.Exited += (s, e) => tcs.TrySetResult(null);
		// not sure on best way to handle false being returned
		if (!process.Start()) tcs.SetException(new Exception("Failed to start process."));
		return tcs.Task;
	}
