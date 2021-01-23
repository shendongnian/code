    private void DBRestoreProgressHandler(DataAccess da, DataAccess.DatabaseRestoreEventArgs e)
        {
            backgroundWorker1.ReportProgress(e.RestoreProgress);
        }
    private void backgroundWorker1_ReportProgress(object sender, ProgressChangedEventArgs e)
        {
            someLabel.Text = e.ProgressPercentage.ToString();
        }
