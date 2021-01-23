    private BackgroundWorker bw = new BackgroundWorker();
            
    bw.WorkerReportsProgress = true;
    bw.WorkerSupportsCancellation = true;
    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
    bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    //load data from database
    System.Threading.Thread.Sleep(1);
    worker.ReportProgress(progressbar_value);
    }
        
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    Progress.value= progressbar_value;
    }
    
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    //progress completed
    }
