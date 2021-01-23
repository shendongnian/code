    public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, Task<TNewResult>> continuationFunction, CancellationToken cancellationToken)
    {
    	var tcs = new TaskCompletionSource<TNewResult>();
    	task.ContinueWith(t => 
    	{
    		if (cancellationToken.IsCancellationRequested)
    		{
    			tcs.SetCanceled();
    		}
    		continuationFunction(t).ContinueWith(t2 => 
            {
                if (cancellationToken.IsCancellationRequested || t2.IsCanceled)
                {
		    		tcs.TrySetCanceled();
			    }
			    else if (t2.IsFaulted)
			    {
			    	tcs.TrySetException(t2.Exception);
			    }
			    else
			    {
				    tcs.TrySetResult(t2.Result);
			    }
            });
    	});
    	return tcs.Task;
    }
