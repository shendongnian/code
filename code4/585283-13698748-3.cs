    private void bgwTest_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        for (int i = 0; i < 11; i++)
        { 
            // use user state for passing data
            // which is not reflecting progress percentage
            worker.ReportProgress(0, i);
            System.Threading.Thread.Sleep(5000);
        }
    }
    private void bgwTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         string valueTExt = e.UserState.ToString();
         qTest.Enqueue(valueTExt);
    }
