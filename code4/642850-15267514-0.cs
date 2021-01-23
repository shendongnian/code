    private BackgroundWorker _worker;
    
    public Form1(string[] args)
    {
        InitializeComponent();
    
    
        _worker = new BackgroundWorker();
        _worker.WorkerReportsProgress = true;
    
        _worker.RunWorkerCompleted += worker_WorkCompleted;
        _worker.DoWork += worker_DoWork;
        _worker.ProgressChanged += worker_ProgressChanged;
    
    
    }
    
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        DoStuff();
    }
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    private void worker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _running = false;
        UpdateUi();
    }
    
    private bool DoStuff()
    {
            //...
            _worker.ReportProgress(20);
            //...
            _worker.ReportProgress(20);
    
            return true;
     
    }
    
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        _worker.RunWorkerAsync();
    }
