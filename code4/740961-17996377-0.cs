    private System.Timers.Timer _timer;
    public static void main()
    {
        _timer = SampleTimer = new Timer(SomeTask,0,70000);
    }
    
    void SomeTask(object o)
    {
        _timer.Enabled = false;
        try{
        // ...  work...
        }finally{
            _timer.Enabled = true;
        }
    }
