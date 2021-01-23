    public static bool isThreadRunning = false;
    
    public void runThread()
    {
        if (!isThreadRunning)
        {
            Thread t = new Thread(new ThreadStart(go));
            t.IsBackground = true;
            t.Name = "myThread";
            t.Start();
        }
        else
        {
          System.Diagnostics.Debug.WriteLine("myThreadis already Running.");
        }   
    }
    public void go()
    {
        isThreadRunning = true;
        //My work goes here
        isThreadRunning = false;
    }
