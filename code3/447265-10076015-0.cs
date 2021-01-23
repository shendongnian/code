    void Main()
    {
    	var t = new Timerr();
    	t.Run();
    	
    	Thread.Sleep(60000);
    }
    
    public class Timerr
     {
    	System.Threading.Timer Timer;
    	System.DateTime StopTime;
    	public void Run()
    	{
    		StopTime = System.DateTime.Now.AddMinutes(1);
    		Timer = new System.Threading.Timer(TimerCallback, null, 0,1000);
    	}
    
    	private void TimerCallback(object state)
    	{
    		if (System.DateTime.Now >= StopTime)
    		{
    			Timer.Dispose();
    			return;
    		}
    		Console.WriteLine("Hello");
    	}
    }
