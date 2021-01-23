    private void btnService_Click(object sender, EventArgs e)
    {
        backgroundWorker.RunWorkerAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        int totalSteps = 10;
    
        for (int i = 1; i <= totalSteps; i++)
        {
            //  One chunk of your code
    
            int progress = i * 100 / totalSteps;
            backgroundWorker.ReportProgress(progress);
        }
    }
    
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        blocksProgressBar.Value = e.ProgressPercentage;
    }
    
    private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
        blocksProgressBar.Value = 0;
    }
