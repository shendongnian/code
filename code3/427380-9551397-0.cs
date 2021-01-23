    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBarAll.Position = e.ProgressPercentage;
        progressBarAll.Text = e.ProgressPercentage.ToString() + "%";
        progressBarFile.Position = e.ProgressPercentage;
        progressBarFile.Text = e.ProgressPercentage.ToString() + "%";
    }
