    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
    	if (startJob())
    	{
    		//if notepad was started, stop the timer
    		DispatcherTimer timer = (DispatcherTimer)sender;
    		timer.Stop();
    	}
    }
