    public void UpdateClock()
    {
    	this.MT_TimerTickCompleted += delegate(object sender, ElapsedEventArgs e)
    	{
    		//When MT_TimerTick occur, do something
    	};
    }
    
    delegate void UpdateClockDelegate();    
    
    private void MT_TimerTick(object source, ElapsedEventArgs e)
    {
        if (InvokeRequired) 
        { 
            MT_TimerTickNotify(object, e); 
        }
    }
    
    public event EventHandler MT_TimerTickCompleted;
    private void MT_TimerTickNotify(object sender, ElapsedEventArgs e)
    {
    	if (MT_TimerTickCompleted != null)
    		MT_TimerTickCompleted(sender, e);
    }
