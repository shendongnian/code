    	timeThreadStarted = DateTime.Now;
    	workerThread = new Thread(RunTask);
    	System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
    	timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    	workerThread.Start(task);
    //...
    
    static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	if(workerThread != null && workerThread.IsAlive)
    	{
    		Console.WriteLine("thread has been running for {0}!", DateTime.Now - timeThreadStarted);
    	}
    }
