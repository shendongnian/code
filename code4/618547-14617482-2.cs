    void Main()
    {
        var canceller = new CancellationTokenSource();
        var task = Task.Factory.StartNew(() => DoStuff(canceller.Token), canceller.Token);        
        if(!task.Wait(2000, canceller.Token))
        {
            canceller.Cancel();
            task.Wait(2);
        }
        sw.Elapsed.Dump();
    }
    private Stopwatch sw;
    private void DoStuff(CancellationToken token)
    {
        try
        {
            sw = Stopwatch.StartNew();
            while(!token.IsCancellationRequested)
            {		
            }
        }
        // no catch - rethrown exceptions must be checked on Task
        finally
        {
            sw.Stop();
        }
    }
