    /// <summary>
    /// Start a new worker
    /// </summary>
    void StartWork()
    {
        var backgroundWorker = new BackgroundWorker();
    
        //make sure the worker reports on progress
        backgroundWorker.WorkerReportsProgress = true;
    
        //we want to get notified when progress has changed
        backgroundWorker.ProgressChanged+=backgroundWorker_ProgressChanged;
    
        //here we do the work
        backgroundWorker.DoWork += backgroundWorker_DoWork;
    
    }
    
    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        //do long work
    }
    
    ProgressBar _progressBar = new ProgressBar();
    void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //when we are notified about progress changed, update the progressbar
        _progressBar.Value = e.ProgressPercentage;
    }
