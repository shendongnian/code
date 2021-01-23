        public MainWindow()
        {
            InitializeComponent();
            
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerAsync();
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // You are in the main thread
            // Update the UI here
            string data = (string)e.UserState;
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // You are in a worker thread
            (sender as BackgroundWorker).ReportProgress(0, "right");
        }
