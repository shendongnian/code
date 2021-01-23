    private static readonly Timer MyTimer = new Timer();
    ...
    const int ONE_SECOND = 1000; // 1000 ms
    MyTimer.Tick += MyTimerTask;
    MyTimer.Interval = ONE_SECOND;
    MyTimer.Enabled = true;
    ...
    private void MyTimerTask(Object o, EventArgs ea)
    {
    	...
    }
