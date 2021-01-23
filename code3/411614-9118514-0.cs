    private DispatcherTimer Timer;
    public Constructor
    {
        Timer = new System.Windows.Threading.DispatcherTimer();
        Timer.Tick += new EventHandler(Timer_Tick);
        Timer.Interval = new TimeSpan(0,0,10);
        Timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        Timer.Stop();
        Timer -= Timer_Tick;
        Timer = null;
        // DO SOMETHING
    }
