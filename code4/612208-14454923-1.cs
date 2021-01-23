    private readonly BackgroundWorker worker = new BackgroundWorker();
    private PerformanceProgressBar loader = new PerformanceProgressBar();
    worker.DoWork += worker_DoWork;
    worker.RunWorkerCompleted += worker_RunWorkerCompleted;
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
       bar.IsIndeterminate = true;
       Bar.Enabled = true;
    }
    private void worker_RunWorkerCompleted(object sender, 
                                           RunWorkerCompletedEventArgs e)
    {
       bar.Enabled = false;
    }
    worker.RunWorkerAsync();
