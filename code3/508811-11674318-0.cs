    using System.Timers;
    using System.Threading;
    
    class Program
    {
    	static MyTask taskInstance = new MyTask();	
    	static ManualResetEventSlim cancelEvent = new ManualResetEventSlim(false);
    	
    	static void Main()
    	{		
    		var timer =  new Timer
    		{
    			AutoReset = true,
    			Interval = 1000
    		};
    		timer.Elapsed += (x, y) => taskInstance.DoWork();
    		cancelEvent.Wait();
    	}
    }
