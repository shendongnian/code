	public static async Task WhenAll(
	    IEnumerable<Task> tasks, 
	    int millisecondsTimeOut,
	    CancellationToken cancellationToken)
	{
	    using(Task timeoutTask = Task.Delay(millisecondsTimeOut))
	    using(Task cancellationMonitorTask = Task.Delay(-1, cancellationToken))
	    {
	        Task completedTask = await Task.WhenAny(
	            Task.WhenAll(tasks), 
	            timeoutTask, 
	            cancellationMonitorTask
	        );
	        if (completedTask == timeoutTask)
	        {
	            throw new TimeoutException();
	        }
	        if (completedTask == cancellationMonitorTask)
	        {
	            throw new OperationCanceledException();
	        }
	    }
	}
