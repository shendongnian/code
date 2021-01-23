    public Form1()
    {
         var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
         dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
         dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
    }
    void PlayClick(object sender, EventArgs e)
    {
                VideoControl.Play();
                dispatcherTimer.Start();
     }
