    private int running;
    public void runThread()
    {
        if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
        {
            Thread t = new Thread
            (
                () =>
                {
                    try
                    {
                        go();
                    }
                    catch
                    {
                        //Without the catch any exceptions will be unhandled
                        //(Maybe that's what you want, maybe not*)
                    }
                    finally
                    {
                        //Regardless of exceptions, we need this to happen:
                        running = 0;
                    }
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
