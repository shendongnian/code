	public static class ParallelOrdered
	{
		public static void ForEach<T>(IEnumerable<T> collection, Action<T> action, int degreeOfParallelism)
		{
			var blockingCollection = new BlockingCollection<T>();
			foreach (var item in collection)
				blockingCollection.Add(item);
			blockingCollection.CompleteAdding();
			var tasks = new Task[degreeOfParallelism];
			for (int i = 0; i < degreeOfParallelism; i++)
			{
				tasks[i] = Task.Factory.StartNew(
					() =>
					{
						foreach (var item in blockingCollection.GetConsumingEnumerable())
							action(item);
					});
			}
			Task.WaitAll(tasks);
		}
	}
