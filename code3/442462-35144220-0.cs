	public void LoopWithDelay<T>(ICollection<T> items, Func<T, Task> action, double interval)
	{
		using (var timer = new System.Timers.Timer(interval))
		{
			var tasks = items.ToDictionary(i => i, i => new Task(() => { }));
			var queue = new ConcurrentQueue<T>(items);
			timer.Elapsed += async (sender, args) =>
			{
				T item;
				if (queue.TryDequeue(out item))
				{
					await action(item);
					// Complete task.
					tasks[item].Start();
				}
			};
			timer.Start();
			Task.WaitAll(tasks.Values.ToArray());
		}
	}
