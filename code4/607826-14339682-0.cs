	// Background timer used to refresh...
	private DispatcherTimer _timer = null;
	private void initializeload()
	{
		// Your existing code here ...
		
		// Start the timer
		_timer = new DispatcherTimer();
		_timer.Tick += Each_Tick;
		_timer.Interval = new TimeSpan(0, 0, 0, 0, 100);	// 100ms
		_timer.Start();	
	}
		
	// Raised every time the timer goes off
	private void Each_Tick(object o, EventArgs sender)
	{
        // Refresh from database etc ...
	}
