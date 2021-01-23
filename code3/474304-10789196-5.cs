	static Task<int> RunProcessAsync(string fileName)
	{
		var tcs = new TaskCompletionSource<int>();
		var process = new Process
		{
			StartInfo = { FileName = fileName },
			EnableRaisingEvents = true
		};
		process.Exited += (sender, args) =>
		{
			tcs.SetResult(process.ExitCode);
			process.Dispose();
		};
		process.Start();
		return tcs.Task;
	}
