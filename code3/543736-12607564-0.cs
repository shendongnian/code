    private dispatcherTimer = new System.Windows.Threading.DispatcherTimer(); 
    ctor
    {
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); 
        dispatcherTimer.Interval = new TimeSpan(0, 0, 10); 
    }
    void PlayClick(object sender, EventArgs e) 
    { 
        VideoControl.Play(); 
        dispatcherTimer.Start(); 
    } 
    private void dispatcherTimer_Tick(object sender, EventArgs e) 
    { 
        dispatchTimer.Stop();
        VideoControl.Pause(); 
    } 
