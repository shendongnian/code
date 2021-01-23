	class TaskProcessor<TResult>
	{
		// TODO: Error handling!
		readonly BlockingCollection<Task<TResult>> blockingCollection = new BlockingCollection<Task<TResult>>(new ConcurrentQueue<Task<TResult>>());
		public Task<TResult> AddTask(Func<TResult> work)
		{
			var task = new Task<TResult>(work);
			blockingCollection.Add(task);
			return task; // give the task back to the caller so they can wait on it
		}
		public void CompleteAddingTasks()
		{
			blockingCollection.CompleteAdding();
		}
		public TaskProcessor()
		{
			ProcessQueue();
		}
		void ProcessQueue()
		{
			Task<TResult> task;
			while (blockingCollection.TryTake(out task))
			{
				task.Start();
				task.Wait(); // ensure this task finishes before we start a new one...
			}
		}
	}
