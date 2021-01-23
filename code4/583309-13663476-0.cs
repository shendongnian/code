    public partial class Progress : Form
    {
        readonly BackgroundWorker _worker = new BackgroundWorker();
        public Progress()
        {
            InitializeComponent();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += WorkerProgressChanged;
            _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            _worker.RunWorkerAsync();
        }
        
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            // Simulate work (uploading Excel records to SQL Server)
            for (var i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                
                // Upload some data here, Sleep(100) is just an example
                Thread.Sleep(100);
                // Calculate current progress and report
                worker.ReportProgress(i);
            }
        }
        
        void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progressBar.Value = e.ProgressPercentage;
        }
        
        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _progressBar.Value = 0;
        }
    }
