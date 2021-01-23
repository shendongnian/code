    Timer _timer;
    
    private void cycleCheckBox_CheckedChanged(object sender, EventArgs e)
    {
    	if(_timer == null )
    	{
    		_timer = new Timer();
    		_timer.Interval = 1000; // 1 second
    		_timer.Tick += DoTimerWork;
    	}
    	
    	if(cycleCheckBox.Checked)
    	{
    		_timer.Start();
    	}
    	else
    	{
    		_timer.Stop();
    	}
    }
    
    private void DoTimerWork(object obj, EventArgs args) 
    {
    	D2.Checked = !D2.Checked;
    }
