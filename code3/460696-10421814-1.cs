    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {   
       BackgroundWorker worker = sender as BackgroundWorker;    
       e.Result = StartLongRunningProcess(worker);
    }
    public void StartLongRunningProcess(BackgroundWorker worker)
    {
       worker.ReportProgress(percentComplete);
    }
