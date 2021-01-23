    private BackgroundWorker worker = new BackgroundWorker();
    
    public MyForm() // Your form's constructor
    {
        InitializeComponent();
        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;
    }
    
    private void btnUpload_Click(object sender, EventArgs e)
    {
        if (!worker.IsBusy) // Don't start it again if already running
        {
            // Start the asynchronous operation.
            // Maybe also disable the button that starts background work (btnUpload)
            worker.RunWorkerAsync();
        }
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        worker.ReportProgress(10);
    
        RunLongProcess();
    
        worker.ReportProgress(20);
    
        RunAnotherLongProcess();
    
        worker.ReportProgress(50);
    
        RunOneMoreLongProcess();
    
        worker.ReportProgress(100); 
    }
    
    // This event handler updates the progress. 
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressbar.value = e.ProgressPercentage;
    }
    
    // This event handler deals with the results of the background operation. 
    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Inform the user that work is complete.
        // Maybe re-enable the button that starts the background worker
    }
