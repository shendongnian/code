    private CancellationTokenSource cancellationSource;
    
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
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (_, args) => DoWork(bgw, cancellationSource);
            bgw.ProgressChanged += (_, args) => label1.Text = args.ProgressPercentage.ToString();
            bgw.WorkerReportsProgress = true;
    
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
    
    private void StopBackgroundTask()
    {
        if (cancellationSource != null)
        {
            cancellationSource.Cancel();
            cancellationSource = null;
        }
    }
