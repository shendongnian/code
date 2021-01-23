    protected CancellationTokenSource _tokenSource = null;
    protected override void OnStart(string[] args)
    {
        _tokenSource = new CancellationTokenSource();
        Task processingTask = new Task(() =>
           {
               while(!_tokenSource.IsCancellationRequested)
               {
                   // Do your processing
               }
           });
        processingTask.Start();
    }
    protected override void OnStop()
    {
        _tokenSource.Cancel();
    }
