    private SmartThreadPool _pool = null;
    private SmartThreadPool Pool 
    {
        get
        {
            if (_pool == null)
                _pool = new SmartThreadPool();
            return _pool;
        }
    }
    
    protected override void OnStop()
    {
       if (Pool != null)
       {
           // Forces all threads to finish and 
           // achieve an idle state before 
           // shutting down
           Pool.WaitForIdle();
           Pool.Shutdown();
       }
    }
