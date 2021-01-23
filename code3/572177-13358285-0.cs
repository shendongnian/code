    //If you want to chain more tasks..
    public static Task<T> Continue<T>(this Task<T> task, Action<T> action)
	{
		if (!task.IsFaulted)
		{
			task.ContinueWith((t) => action(t.Result), TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion);
		}
		return task;
	}
    public static Task OnException(this Task task, Action<Exception> onFaulted)
	{
		task.ContinueWith(c =>
		{
			var excetion = c.Exception;
				onFaulted(excetion);
		},
			TaskContinuationOptions.OnlyOnFaulted |
			TaskContinuationOptions.ExecuteSynchronously);
		return task;
	}
