    protected override void Execute()
    {
        new System.Threading.ManualResetEvent(false).WaitOne(5000);
    
        Result = Task.Factory.StartNew(() => new Dictionary<string, string[]>());
    }
