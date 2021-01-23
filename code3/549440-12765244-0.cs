    private BackgroundWorker _backgroundWorker;
    public void MethodName( )
    {
        _backgroundWorker = new BackgroundWorker();
        _backgroundWorker.WorkerReportsProgress = true;
        _backgroundWorker.DoWork +=
          new DoWorkEventHandler(BackgroundWorker_DoWork);
        _backgroundWorker.ProgressChanged +=
          new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        _backgroundWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
        // Start the BackgroundWorker
        _backgroundWorker.RunWorkerAsync();
    }
    void BackgroundWorker_RunWorkerCompleted(object sender,
                                             RunWorkerCompletedEventArgs e)
    {
        // This method runs in the UI thread.
        // Work is finished! You can display the work done by using e.Result
    }
    void BackgroundWorker_ProgressChanged(object sender,
                                          ProgressChangedEventArgs e)
    {
        // This method runs in the UI thread.
        // Report progress unsing the value e.ProgressPercentage.
    }
    void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // This method runs in a background thread.
        while (true) {
            // Do some work here
            _backgroundWorker.ReportProgress(percentage_done);
            // You don't need to calculate the percentage number if you don't
            // need it in BackgroundWorker_ProgressChanged.
        }
        // You can set e.Result = to some result;
    }
