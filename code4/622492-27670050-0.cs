    public static async Task<T> GetFirstResult<T>(
    this IEnumerable<Func<CancellationToken, Task<T>>> taskFactories, 
    Action<Exception> exceptionHandler,
    Predicate<T> predicate)
    {
    	T ret = default(T);
    	var cts = new CancellationTokenSource();
    	var proxified = taskFactories.Select(tf => tf(cts.Token)).ProxifyByCompletion();
    	int i;
    	for (i = 0; i < proxified.Length; i++)
    	{
    		try
    		{
    			ret = await proxified[i].ConfigureAwait(false);
    		}
    		catch (Exception e)
    		{
    			exceptionHandler(e);
    			continue;
    		}
    		if (predicate(ret))
    		{
    			break;
    		}
    	}
    	
    	if (i == proxified.Length)
    	{
    		throw new InvalidOperationException("No task returned the expected value");
    	}
    	cts.Cancel(); //we have our value, so we can cancel the rest of the tasks
    	for (int j = i+1; j < proxified.Length; j++)
    	{
    		//observe remaining tasks to prevent process crash 
    		proxified[j].ContinueWith(
             t => exceptionHandler(t.Exception), TaskContinuationOptions.OnlyOnFaulted)
                       .Forget();
    	}
    	return ret;
    }
