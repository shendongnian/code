    public void ProgressDialog(BackgroundWorker worker)
    {
       worker.ProgressChanged += ProgressDialog_ProgressChanged;
    }
    private void ProgressDialog_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       UpdateProgressBar(e.ProgressPercentage);
    }
