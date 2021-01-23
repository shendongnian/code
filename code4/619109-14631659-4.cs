    public static Task Then(this Task parent, Func<Task> nextFunc)
    {
    	TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
    	parent.ContinueWith(pt =>
    	{
    		if (pt.IsFaulted)
    		{
    			tcs.SetException(pt.Exception.InnerException);
    		}
    		else
    		{
    			Task next = nextFunc();
    			next.ContinueWith(nt =>
    			{
    				if (nt.IsFaulted)
    				{
    					tcs.SetException(nt.Exception.InnerException);
    				}
    				else { tcs.SetResult(null); }
    			});
    		}
    	});
    	return tcs.Task;
    }
