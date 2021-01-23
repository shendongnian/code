    private BackgroundWorker _backgroundWorker;
    public void Setup( )
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
    void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // This method runs in a background thread. Do not access the UI here!
        while (work not done) {
            // Do your background work here!
            // Send messages to the UI:
            _backgroundWorker.ReportProgress(percentage_done, user_state);
            // You don't need to calculate the percentage number if you don't
            // need it in BackgroundWorker_ProgressChanged.
        }
        // You can set e.Result = to some result;
    }
    void BackgroundWorker_ProgressChanged(object sender,
                                          ProgressChangedEventArgs e)
    {
        // This method runs in the UI thread and receives messages from the backgroud thread.
        // Report progress using the value e.ProgressPercentage and e.UserState
    }
    void BackgroundWorker_RunWorkerCompleted(object sender,
                                             RunWorkerCompletedEventArgs e)
    {
        // This method runs in the UI thread.
        // Work is finished! You can display the work done by using e.Result
    }
