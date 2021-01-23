    public void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Invoke(new ProgressDelegate(UpdateProgress), e.ProgressPercentage);
    }
    delegate void ProgressDelegate(decimal value);
    private void UpdateProgress(decimal value)
    {
        progressBar1.Value = value;
    }
            
