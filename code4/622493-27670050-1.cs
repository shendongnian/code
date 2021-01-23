    public static Task<T>[] ProxifyByCompletion<T>(this IEnumerable<Task<T>> tasks)
    {
    	var inputTasks = tasks.ToArray();
    	var buckets = new TaskCompletionSource<T>[inputTasks.Length];
    	var results = new Task<T>[inputTasks.Length];
    	for (int i = 0; i < buckets.Length; i++)
    	{
    		buckets[i] = new TaskCompletionSource<T>();
    		results[i] = buckets[i].Task;
    	}
    	int nextTaskIndex = -1;
    	foreach (var inputTask in inputTasks)
    	{
    		inputTask.ContinueWith(completed =>
    		{
    			var bucket = buckets[Interlocked.Increment(ref nextTaskIndex)];
    			if (completed.IsFaulted)
    			{
    				Trace.Assert(completed.Exception != null);
    				bucket.TrySetException(completed.Exception.InnerExceptions);
    			}
    			else if (completed.IsCanceled)
    			{
    				bucket.TrySetCanceled();
    			}
    			else
    			{
    				bucket.TrySetResult(completed.Result);
    			}
    		}, CancellationToken.None, 
               TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    	}
    	return results;
    }
