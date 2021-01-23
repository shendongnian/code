    private Thread thread;
    
    public void runThread()
    {
        if (thread == null || !thread.IsAlive)
        {
            thread = new Thread(go);
            thread.IsBackground = true;
            thread.Name = "myThread";
            thread.Start();
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("myThreadis already Running.");
        }
    }
    
    public void go()
    {
        //My work goes here
    }
