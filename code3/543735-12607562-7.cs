    var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    public Form1() //// form constructor where you are handling these all event....
    {
         dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
         dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
    }
    void PlayClick(object sender, EventArgs e)
    {
                VideoControl.Play();
                dispatcherTimer .Start();
    }
