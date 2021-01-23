    void Main()
    {    
        for (int i = 0; i < 10000; i++)
        {
            Task task = Delay (2000);
            task.ContinueWith (_ => "Done".Dump());
        }
    }
     
    Task Delay (int milliseconds)        // Asynchronous NON-BLOCKING method
    {
        var tcs = new TaskCompletionSource<object>();
        new Timer (_ => tcs.SetResult (null)).Change (milliseconds, -1);
        return tcs.Task;
    }
