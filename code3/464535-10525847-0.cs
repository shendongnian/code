        InitializeComponent();
        backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true;
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
    }
    public string Input
    {
        get { return input; }
        set
        {
            if (value == input) return;
            value = value.Trim();
            input = value;
            NotifyPropertyChanged("Input");
            if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();
            dispatcherTimer.Stop();                
            dispatcherTimer.Start();
        }
     }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        dispatcherTimer.Stop();
        if (!backgroundWorker1.IsBusy)
        {
            backgroundWorker1.RunWorkerAsync(Input);
        }
    }
