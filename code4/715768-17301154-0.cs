    private System.Timers.Timer _timer;
    private int _countSeconds;
    
    void Main()
    {
        _timer = new System.Timers.Timer();
    	//Trigger event every second
    	_timer.Interval = 1000;
    	_timer.Elapsed += OnTimedEvent;
        //count down 5 seconds
    	_countSeconds = 5;
        _timer.Enabled = true;
    }
    
    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
    	_countSeconds--;
    	
    	//Update visual representation here
        //Remember to do it on UI thread
    	
    	if (_countSeconds == 0)
    	{
    		_timer.Stop();
    	}
    }
