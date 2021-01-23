    private System.Windows.Forms.Timer ToolTipTimer = new Timer();
    
    public MyControl()
    {
        myToolTip.Popup += ToolTipPopup;
        ToolTipTimer.Tick += ToolTipTimerTick;
        ToolTipTimer.Enabled = false;
    }
    
    private bool IsToolTipShowing { get; set; }
    
    private Control ToolTipControl { get; set; }
    
    private void ToolTipPopup(object sender, PopupEventArgs e)
    {
       var control = e.AssociatedControl;
    
       //optionally check to see if we're interested in watching this control's ToolTip    
       
       ToolTipControl = control;
       ToolTipControl.MouseLeave += ToolTipMouseLeave;
       ToolTipAutoPopTimer.Interval = myToolTip.AutoPopDelay;
       ToolTipTimer.Start(); 
       IsToolTipShowing = true;
    }
    
    //now one of these two should happen to stop the ToolTip showing on the currently-watched control
    public void ToolTipTimerTick(object sender, EventArgs e)
    {
       StopToolTip();
    }
    
    public void ToolTipMouseLeave(object sender, EventArgs e)
    {
       StopTimer();
    }
    
    private void StopTimer()
    {
       IsToolTipShowing = false;
       ToolTipTimer.Stop();
       ToolTipControl.MouseLeave -= ToolTipMouseLeave;
    }
