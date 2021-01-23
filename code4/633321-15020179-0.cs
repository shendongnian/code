      public partial class frmWait : Form
    {
        private BackgroundWorker worker;
        public frmWait()
        {
            InitializeComponent();
            this.worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };
            this.worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            this.worker.DoWork += WorkerOnDoWork;
            this.worker.ProgressChanged += WorkerOnProgressChanged;
            this.worker.RunWorkerAsync();
        }
        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update UI or something else
        }
        private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            // Do background-stuff here
        }
        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Actions after BackgroundWorker is done
            Close();
        }
    }
