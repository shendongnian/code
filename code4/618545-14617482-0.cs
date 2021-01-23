    void Main()
    {
        var canceller = new CancellationTokenSource();
        var task = Task.Factory.StartNew(DoStuff, canceller.Token);
        task.Wait(2000, canceller.Token);
        sw.Elapsed.Dump();
    }
    private Stopwatch sw;
    private void DoStuff()
    {
        try
        {
            sw = Stopwatch.StartNew();
            while(true)
            {		
            }
        }
        catch(Exception ex)
        {
        }
        finally
        {
            sw.Stop();
        }
    }
