	public static T GetResult<T>(Func<Task<T>> func)
	{
		var httpContext = HttpContext.Context;
		var proxyTask = Task.Run(() =>
		{
			HttpContext.Context = httpContext;
			return func();
		});
		return proxyTask.Result;
	}
	// or
	public static T GetResult<T>(Func<Task<T>> task)
	{
		var syncContext = SynchronizationContext.Current;
		SynchronizationContext.SetSynchronizationContext(null);
		var task = func();
		SynchronizationContext.SetSynchronizationContext(syncContext);
		return task.Result;
	}
