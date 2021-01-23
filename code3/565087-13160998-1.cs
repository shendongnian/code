    private CancellationTokenSource cancellationSource;
    private Task asyncOperationCompleted;
    
    private void button1_Click(object sender, EventArgs e)
    {
        //cancel previously running operation before starting a new one
        if (cancellationSource != null)
        {
            cancellationSource.Cancel();
        }
        else //take out else if you want to restart here when `start` is pressed twice.
        {
            cancellationSource = new CancellationTokenSource();
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            asyncOperationCompleted = tcs.Task;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (_, args) => DoWork(bgw, cancellationSource);
            bgw.ProgressChanged += (_, args) => label1.Text = args.ProgressPercentage.ToString();
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerCompleted += (_, args) => tcs.SetResult(true);
    
            bgw.RunWorkerAsync();
        }
    }
    
    private void DoWork(BackgroundWorker bgw, CancellationTokenSource cancellationSource)
    {
        int i = 0;
        while (!cancellationSource.IsCancellationRequested)
        {
            Thread.Sleep(1000);//placeholder for real work
            bgw.ReportProgress(i++);
        }
    }
    
    private void StopAndWaitOnBackgroundTask()
    {
        if (cancellationSource != null)
        {
            cancellationSource.Cancel();
            cancellationSource = null;
    
            asyncOperationCompleted.Wait();
        }
    }
