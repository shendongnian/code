    private Timer _timer;
	public bool TimerEnabled
	{
   		get { return _timer.Enabled; }
   		set { _timer.Enabled = value; }
	}
	void InitializeTimer()
	{
    	_timer = new Timer();
    	_timer.Interval = 1; //One millisecond
        _timer.Enabled = false;
   		_timer.Tick += new EventHandler(_timer_Tick);
	}
    void _timer_Tick(object sender, EventArgs e)
    {
        //Example
        Location = new Point(Location.X, Location.Y + 1);
    }
