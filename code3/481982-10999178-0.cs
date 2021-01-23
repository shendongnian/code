    var worker = new BackgroundWorker {WorkerReportsProgress = true};
    worker.DoWork += this.ThreadWorkMethod;
    worker.ProgressChanged += this.ThreadProgressMethod;
    worker.RunWorkerAsync();
    ...
    private void ThreadWorkMethod(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        for (int i = 0; i = 1000; i++)
        {
            // Time consuming operation
            Thread.Sleep(1000);
            worker.ReportProgress(i * 100d / 1000, i);
        }
    }
    private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Here you can access controls, etc.
        if (e.Progresspercentage == 100)
        {
            this.progLabel.Text = "100% Done";
        }
        else
        {
            this.progLabel.Text = string.Format("{0}% ({1} / 1000)",
                                                e.ProgressPercentage,
                                                e.UserState);
        }
    }
