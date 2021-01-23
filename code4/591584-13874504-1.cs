    private void parseButton_Click(object sender, EventArgs e)
    {
        parseButton.Enabled = false;
        myBGWorker.RunWorkerAsync();
    }
    
    private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       for(int i = 0; i < filesCount; i++)
       {  
           ParseSingleFile(); // pass filename here
           int percentage = (i + 1) * 100 / filesCount;
           myBGWorker.ReportProgress(percentage);
       }
    }
    
    void myBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        myProgressBar.Value = e.ProgressPercentage;
    }
    
    void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        parseButton.Enabled = true;
        MessageBox.Show("Done");
    }
