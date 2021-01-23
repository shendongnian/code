    sealed class Q:IDisposable
    {
    	private CancellationTokenSource cts=new CancellationTokenSource();
    	private BlockingCollection<Action> queue=
    		new BlockingCollection<Action>();
    	
    	public Q()
    	{
    		new Thread(()=>RunQueue()).Start();
    	}
    	
    	private void RunQueue()
    	{
    		while(!cts.IsCancellationRequested)
    		{
    			//lovely... blocks until something is available
    			var action=queue.Take(cts.Token); 
    			action();
    		}
    	}
    	
    	public void AddJob(Action action)
    	{
    		queue.Add(action,cts.Token);
    	}
    	
    	public void Dispose()
    	{
    		if(!cts.IsCancellationRequested)
    		{
    			cts.Cancel();
    		}
    	}
    }
