    private bool _doubleClicked = false;
    private Timer _clickTrackingTimer = 
        new Timer(SystemInformation.DoubleClickTimer + 100);
    private void ClickHandler(object sender, EventArgs e)
    {
        _clickTrackingTimer.Start();
    }
    private void DoubleClickHandler(object sender, EventArgs e)
    {
        _doubleClicked = true;
    }
    private void TimerTickHandler(object sender, EventArgs e)
    {
        _clickTrackingTimer.Stop();
        if (!_doubleClicked)
        {
            // single click!
        }
  
        _doubleClicked = false;
    }
