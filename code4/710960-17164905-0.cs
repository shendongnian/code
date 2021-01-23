     private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
       var worker = (BackgroundWorker)sender;
       // time consuming operation
       worker.ReportProgress(10, null);
       // ... another stuff
     }
     private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
         progressBar.Value = e.ProgressPercentage;
     }
 
