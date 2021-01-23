    public MainViewModel()
    {
        initializeload();
        timer.Tick += new EventHandler(timer_Tick);
        timer.Interval = new TimeSpan(0, 0, 15);
        timer.Start();
    }
    ~MainViewModel()
    {
        Dispose(false);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                timer.Stop();
                timer.Tick -= new EventHandler(timer_Tick);
            }
            disposed = true;
        }
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        try 
        {
            SystemStatusData.Clear();
            initializeload();
        } 
        catch (...) 
        {
            // Problem best to stop the timer if there is an error...
            timer.Stop();
        }
    }
    private bool disposed;
    private DispatcherTimer timer = new DispatcherTimer();
    
