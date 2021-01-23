    using Timer = System.Windows.Forms.Timer;
    private static readonly Timer MyTimer = new Timer();
    ...
    MyTimer.Tick += MyTimerTask;
    MyTimer.Interval = 200; // ms
    MyTimer.Enabled = true;
    ...
    private void MyTimerTask(Object o, EventArgs ea)
    {
    	...
    }
