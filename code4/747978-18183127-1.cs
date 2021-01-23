    System.Timers.Timer timer;
    void SetupTimer()
    {
        timer= new System.Timers.Timer();//create timer
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);//attach event handler
        timer.Interval = 1000;//set to fire every 1 second
        timer.Enabled = true;//starts the timer
    }
    void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        DoTasks();
    }
    
    void DoTasks()
    {
        readInputs();
        process();    
    }
