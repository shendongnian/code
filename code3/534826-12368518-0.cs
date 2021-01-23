    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
            
        // .. stuff that takes long
        backgroundWorker1.ReportProgress(10);
        // .. stuff that takes long
        backgroundWorker1.ReportProgress(20);
        
        // .. stuff that takes long
        backgroundWorker1.ReportProgress(100);
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Done !
    }
