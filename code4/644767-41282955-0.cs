	public static T GetResult<T>(this Task<T> task)
	{
		if (task.IsCompleted)
			return task.Result;
		return Task.Run(async () => await task).Result;
	}
