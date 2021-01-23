    backgroundWorker1.DoWork += backgroundWorker1_DoWork;
    backgroundWorker1.ProgressChanged +=backgroundWorker1_ProgressChanged;
       private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
         {
           ....
           backgroundWorker1.ReportProgress(i);
           ....
         }
      private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           progressBar1.Value = e.ProgressPercentage;
        }
