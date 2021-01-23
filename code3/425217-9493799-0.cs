	for (int index = 0; index < numberOfTasks; index++)
	{
		int capturedIndex = index;
		rudeTasks.Add(Task.Factory.StartNew(() =>
		{
			Console.WriteLine("Starting rude task {0} at {1}ms", capturedIndex, timer.ElapsedMilliseconds);
			Thread.Sleep(3000);
		}, TaskCreationOptions.LongRunning));
	}
