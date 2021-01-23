    public WMPLib.IWMPMedia latest_song;
    public WMPLib.IWMPMedia current_song;
    
    private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
    {
    	if (e.newState == 9 && repeat) { axWindowsMediaPlayer1.Ctlcontrols.playItem(latest_song); return; }
    	
    	if (e.newState == 8) // media ended
    	{
    		if (repeat)
    		{
    			latest_song = current_song;
    		}
    	}
    	else if (e.newState == 3) // playing
    	{
    		if (repeat) { return; }
    		current_song = axWindowsMediaPlayer1.Ctlcontrols.currentItem;
            // your stuff
    	}
      
    }
