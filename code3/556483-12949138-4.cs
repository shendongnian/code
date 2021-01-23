    private int running;
    public void runThread()
    {
        if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
        {
            Thread t = new Thread
            (
                () =>
                {
                    go();
                    running = 0;
                }
            );
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
        //My work goes here
    }
