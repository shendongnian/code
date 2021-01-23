	public void FetchProduct(TimeSpan timeout)
	{
		var fetchTask = Task<ProductEventArgs>.Factory.StartNew(
			() =>
			{
				try
				{
					// long operation which return new ProductEventArgs with a list of product
				}
				catch(Exception e)
				{
					return new ProductEventArgs() { E = e };
				}
			});
		Task<ProductEventArgs> resultTask;
		if(timeout != Timeout.InfiniteTimeSpan)
		{
			var timeoutTask = Task.Delay(timeout);
			resultTask = Task.WhenAny(resultTask, timeoutTask).ContinueWith<ProductEventArgs>(
				t =>
				{
					// completed task is the result of WhenAny
					if(t.Result == fetchTask)
					{
						return fetchTask.Result;
					}
					else
					{
						return new ProductEventArgs() { E = new TimeoutException() };
					}
				});
		}
		else
		{
			resultTask = fetchTask;
		}
		resultTask.ContinueWith(x => handleResult(x.Result), TaskScheduler.FromCurrentSynchronizationContext());
	}
