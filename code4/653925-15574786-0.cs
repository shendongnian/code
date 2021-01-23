    public bool ended = false;
    public WMPLib.IWMPMedia latest_song;
    
    private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
    {
        if (ended)
        {
            axWindowsMediaPlayer1.Ctlcontrols.playItem(latest_song);
            ended = false;
            return;
        }
    
        if (e.newState == 8) // media ended
        {
            if (repeat)
            {
                ended = true;
                latest_song = axWindowsMediaPlayer1.Ctlcontrols.currentItem;
            }
        }
    }
