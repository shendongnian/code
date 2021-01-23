    void Application_Start(object sender, EventArgs e)
    {
        if (_timer == null)
        {
            _timer = new Timer();
            _timer.Interval = 1000; // some interval
            _timer.Elapsed += new ElapsedEventHandler(SomeStaticMethod);
            _timer.Start();
        }
    }
