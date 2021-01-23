    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
          backgroundWorker.ReportProgress(80, 15000);
    }
    
    private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         var numberOfPackets = int.parse(e.UserState);
    
         MessageBox.Show("Percentage: " + e.ProgressPercentage );
         MessageBox.Show("Packets sent :" + numberOfPackets);  
    }
