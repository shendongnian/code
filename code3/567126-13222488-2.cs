    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        int count = 0;
        BackgroundWorker Worker = (BackgroundWorker)sender;
        while (count < 10000000)
        {
            Worker.ReportProgress(count);
            count++;
        }
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Dispatcher.BeginInvoke((Action)(() => { txt.Text = e.ProgressPercentage.ToString(); }));
    }
