    private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       var worker = sender as BackgroundWorker;
       for(int i = 0; i < filesCount; i++)
       {  
           ParseSingleFile(); // pass filename here
           int percentage = (i + 1) * 100 / filesCount;
           worker.ReportProgress(percentage);  // use not myBGWorker but worker from sender
       }
    }
