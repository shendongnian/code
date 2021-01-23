    protected override void Execute()
    {
        Result = Task.Factory.StartNew(() =>
        {
            new System.Threading.ManualResetEvent(false).WaitOne(5000);
            return new Dictionary<string, string[]>();
        });
    }
