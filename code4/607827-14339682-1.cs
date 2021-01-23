    // Background timer used to refresh...
    private DispatcherTimer _timer = null;
    public MainViewModel()
    {
        // Do initial load
        initializeload();
	    
        // Start the timer to refresh every 100ms thereafter (change as required)
        _timer = new DispatcherTimer();
        _timer.Tick += Each_Tick;
        _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        _timer.Start();	
    }
		
    // Raised every time the timer goes off
    private void Each_Tick(object o, EventArgs sender)
    {
        // Refresh from database etc ...
        initializeload();
        // Anything else you need ...
    }
    private void initializeload()
    {
        // Your existing code here ...
    }
