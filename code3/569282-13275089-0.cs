    private void button1_Click(object sender, EventArgs e)
    {
        BackgroundWorker bgw = new BackgroundWorker();
    
        bgw.DoWork += (_, args) => LongRunningTask(bgw);
        bgw.ProgressChanged += (_, args) =>
        {
            textbox1.Text = args.ProgressPercentage.ToString();
        };
        bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
    }
    
    private void LongRunningTask(BackgroundWorker bgw)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(1000);//placeholder for real work
            bgw.ReportProgress(i);
        }
    }
    
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //do stuff when completed.
    }
