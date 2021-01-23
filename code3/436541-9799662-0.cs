    BackgroundWorker bw = new BackgroundWorker();
    
    
    bw.WorkerSupportsCancellation = true;
    bw.WorkerReportsProgress = true;
    
    
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
    
        for (int i = 1; (i <= 10); i++)
        {
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress((i * 10));
            }
        }
    }
    
    
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
    }
    
    
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if ((e.Cancelled == true))
        {
            this.tbProgress.Text = "Canceled!";
        }
    
        else if (!(e.Error == null))
        {
            this.tbProgress.Text = ("Error: " + e.Error.Message);
        }
    
        else
        {
            this.tbProgress.Text = "Done!";
        }
    }
