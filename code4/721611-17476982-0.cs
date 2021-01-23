    BackgroundWorker bw;
    
    YourFormConstructor()
    {
        ...
        bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        bw.DoWork += BackgroundCalculations;
        bw.ProgressChanged += ShowBackgroundProgress;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
      bw.RunWorkerAsync(10);
    }
    void ShowBackgroundProgress(object sender, ProgressChangedEventArgs e)
    {
        this.progressBar.Value = e.ProgressPercentage;
    }
    
    static void BackgroundCalculations(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker bw = sender as BackgroundWorker;
    
        int max = (int)e.Argument;
        for (int i = 0; i < max; i++)
        {
            bw.ReportProgress(i * 100 / max);
            Thread.Sleep(10);
        }
    
        bw.ReportProgress(100);
        }
    }
