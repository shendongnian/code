    public proForm()
    {
        InitializeComponent();
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true;
    }
    proForm_Load()
    {
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    
        (int i = 0; i < 101; i++) worker.ReportProgress(i);
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
    }
      
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.Close();
    }
