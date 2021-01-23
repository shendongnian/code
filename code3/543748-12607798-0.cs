    AutoResetEvent auto = new AutoResetEvent();
    Timer t = new Timer();
    t.Interval = 2000;
    timer1.Enabled = true;
    timer1.Tick += new System.EventHandler(OnTimerEvent);
    Auto.WaitOne();
    Return; //  exit
