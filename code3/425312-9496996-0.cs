	var task = Task.Factory.StartNew(() =>
	{
		throw new Exception("oops!");
	});
	// attach an exception-handling task
	task.ContinueWith(previousTask =>
	{
		// do something with the exception
		Console.WriteLine(previousTask.Exception);		
		
	}, TaskContinuationOptions.OnlyOnFaulted);
