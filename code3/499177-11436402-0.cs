    public class DoSomethingService
    {
    	private volatile bool _stopped = false;
    
    	public void Start(object socketQueueObject)
    	{
    		while (!_stopped)
    		{
    			...
    		}
    	}
    
    	public void Stop()
    	{
    		_stopped = true;
    	}
    }
    ...
    var doSomethingService = DoSomethingService();
    doSomethingService.Start();
    ...
    doSomethingService.Stop();
