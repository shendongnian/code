    //Declare Timer
    private Timer _timer= new Timer();
    void Loopy(int _time)
    {
        
        _timer.Interval = _time;
        _timer.Enabled = true;
        _timer.Tick += new EventHandler(timer_Elapsed);
        _timer.Start();
    }
    
    void timer_Elapsed(object sender, EventArgs e)
    {
        //Do your stuffs here
    }
