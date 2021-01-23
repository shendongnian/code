    public static Task WaitForReady(this B b)
    {
    	TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
    	Action handler = null;
    	handler = () =>
    	{
    		if (b.State == State.Ready)
    		{
    			b.StateChanged -= handler;
    			tcs.SetResult(null);
    		}
    	};
    
    	b.StateChanged += handler;
    	return tcs.Task;
    }
