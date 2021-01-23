    Timer r = new System.Timers.Timer(timeout_in_ms);
    r.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    r.Enabled = true;
    running = true;
    while (running) {
       // do stuff
    }
    r.Enabled = false;
    
    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
       running = false;
    }
