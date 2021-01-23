    public static CancellationTokenSource cancelSource ;
    void Main()
    {
        RetryAction(() => Sleep(), 500);
    }
    public static void RetryAction(Action action, int timeout)
    {
         cancelSource = new CancellationTokenSource();                
         cancelSource.CancelAfter(timeout);
         Task.Run(() => action(), cancelSource.Token);    
    }
    public static void Sleep() 
    {
    	for(int i = 0 ; i< 50; i++)
    	{
    		"Waiting".Dump();
        	System.Threading.Thread.Sleep(100);
	
	    	if (cancelSource.IsCancellationRequested)
	    	{
	    		"Cancelled".Dump();
	    		return;
    		}
    	}
        "done".Dump();
    }
