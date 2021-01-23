	var ui = TaskScheduler.FromCurrentSynchronizationContext();
	someList
		.ForEach(f => Task.Factory.StartNew(() =>
		{
			// do stuff
		})
		.ContinueWith(task =>
		{
			if (task.IsCompleted)
			{
				// update UI
                // called after each task above completes
			}
		}, ui));
