    private void bw_Convert_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       //The progress in percentage
       int progress = e.ProgressPercentage;
       //A custom-value you can pass by calling ReportProgress in DoWork
       object obj = e.UserState;
    }
