    private void cmdButton_Click(object sender, EventArgs e)
    {
        var worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        DoWorkEventHandler doWork = (dws, dwe) =>
        {
            for (int i = 0; i < 101; i++)
            {
                worker.ReportProgress(i);
                System.Threading.Thread.Sleep(100);
            }
        };
        ProgressChangedEventHandler progressChanged = (pcs, pce) =>
        {
            lblProgress.Text = String.Format("Progress: {0}%", pce.ProgressPercentage);
        };
        RunWorkerCompletedEventHandler runWorkerCompleted = null;
        runWorkerCompleted = (rwcs, rwce) =>
         {
             worker.DoWork -= doWork;
             worker.ProgressChanged -= progressChanged;
             worker.RunWorkerCompleted -= runWorkerCompleted;
             worker.Dispose();
             lblProgress.Text = "Done.";
         };
        worker.DoWork += doWork;
        worker.ProgressChanged += progressChanged;
        worker.RunWorkerCompleted += runWorkerCompleted;
        worker.RunWorkerAsync();
    }
