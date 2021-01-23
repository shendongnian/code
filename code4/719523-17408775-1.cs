	public static Task WaitForFileAsync(string path)
	{
		if (File.Exists(path)) return Task.FromResult<object>(null);
		var tcs = new TaskCompletionSource<object>();
		FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(path));
		watcher.Created += (s, e) => 
		{ 
			if (e.FullPath.Equals(path))
			{ 
				tcs.TrySetResult(null);
				if (watcher != null)
				{
					watcher.EnableRaisingEvents = false;
					watcher.Dispose();
				}
			} 
		};
		watcher.Renamed += (s, e) =>
		{
			if (e.FullPath.Equals(path))
			{
				tcs.TrySetResult(null);
				if (watcher != null)
				{
					watcher.EnableRaisingEvents = false;
					watcher.Dispose();
				}
			}
		};
		watcher.EnableRaisingEvents = true;
		return tcs.Task;
	}
