    // initialize the worker
    BackgroundWorker backgroundWorker1 = new BackgroundWorker();
    backgroundWorker1.WorkerReportsProgress = true;
    backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
    backgroundWorker1.RunWorkerAsync();
    // thread 2 (BackgroundWorker) 
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // main loop
        while(true) 
        {
            // time-consuming work
            // raise the event; use the state object to pass any information you need
            ReportProgress(0, state);
        }
    }
    // this code will run on the GUI thread
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // get your state back
        object state = e.UserState;
        // update GUI with state
    }
