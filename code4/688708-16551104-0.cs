    int seconds = 4;
    System.Timers.Timer _clientTimer = new System.Timers.Timer(seconds * 1000);
    _clientTimer.AutoReset = false;
    _clientTimer.Elapsed += clientTimer_Elapsed;
    _clientTimer.Start();
    
    private void clientTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
    	try
    	{
    		// Connect to web service, get status, if status != 0 do something...
    	}
    	finally
    	{
    		_clientTimer.Start();
    	}
    }
