    public void TimerSetup() {
        Timer timer1 = new Timer();
        timer1.Interval = 1000;     //timer will fire every second
        timer1.Tick += OnTimedEvent;
        timer1.Enabled = true;
        timer1.Start();
    }
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
