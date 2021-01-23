     public MainWindow()
     {
        InitializeComponent();
     
        backgroundworker.WorkerReportsProgress = true;
        backgroundworker.WorkerSupportsCancellation = true;
        backgroundworker.DoWork += backgroundworker_DoWork;
        backgroundworker.ProgressChanged += backgroundworker_ProgressChanged;
    }
    
    private void buttonStop_Click(object sender, RoutedEventArgs e)
    {
        backgroundworker.CancelAsync();
        e.Handled = true;
    }
    
    private void buttonStart_Click(object sender, RoutedEventArgs e)
    {
        if (backgroundworker.IsBusy == false)
        {
           backgroundworker.RunWorkerAsync();
        }
        e.Handled = true;
    }
    
    void backgroundworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    void backgroundworker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        if (worker != null)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                
                System.Threading.Thread.Sleep(50);
                worker.ReportProgress(i);
            }
        }
    }
