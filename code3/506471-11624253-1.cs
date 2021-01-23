    private void cmdButton_Click(object sender, EventArgs e)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        worker.RunWorkerAsync();
    }
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 0; i < 101; i++)
        {
            worker.ReportProgress(i);
            System.Threading.Thread.Sleep(1000);
        }
    }
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        lblProgress.Text = ("Progress: " + e.ProgressPercentage.ToString() + "%");
    }
