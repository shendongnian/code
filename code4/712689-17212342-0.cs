    //worker class   
    private volatile bool _stopping;
    private Thread _thread;
    public void Start()
    {
        _stopping = false;
        Directory.CreateDirectory(_folder);
        _thread = new Thread(Process);
        _thread.Start();
        Feedback(this, "[" + _name + "] started!");
    }
    public void Stop()
    {
        _stopping = true;
        _thread.Join();
        Feedback(this, "[" + _name + "] stopped...");
    }
    private void Process()
    {
         while(!_stopping)
         {
             ......
             Thread.Sleep(100);
         }
    }
  
