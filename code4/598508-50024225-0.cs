    public static async Task RunLimitedNumberAtATime<T>(int numberOfTasksConcurrent, 
		IEnumerable<T> inputList, Func<T, Task> asyncFunc)
	{
		Queue<T> inputQueue = new Queue<T>(inputList);
		List<Task> runningTasks = new List<Task>(numberOfTasksConcurrent);
		for (int i = 0; i < numberOfTasksConcurrent && inputQueue.Count > 0; i++)
			runningTasks.Add(asyncFunc(inputQueue.Dequeue()));
		while (inputQueue.Count > 0)
		{
			Task task = await Task.WhenAny(runningTasks);
			runningTasks.Remove(task);
			runningTasks.Add(asyncFunc(inputQueue.Dequeue()));
		}
		await Task.WhenAll(runningTasks);
	}
