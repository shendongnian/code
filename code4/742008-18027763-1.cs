    public void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<object, ProgressChangedEventArgs>(backgroundWork1_ProgressChanged), sender, e);
            return;
        }
        this.progressBar.Value = e.ProgressPercentage;
    }
