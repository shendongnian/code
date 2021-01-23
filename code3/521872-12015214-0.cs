    DateTime _startTime=DateTime.Now;
    TimeSpan _elapsedTime;
    
    
    .....
    
    thread.Start();
    while(thread.IsAlive)
    {
     Thread.Sleep(100);
    }
    
    
    private static void scanner(string folder, string patterns)
    {
    
    
    // do your work here
    
    _elapsedTime=DateTime.Now.Subtract(_startTime);
    
    }
