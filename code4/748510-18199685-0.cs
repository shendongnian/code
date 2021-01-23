    public partial class Form1 : Form
    {
        private Form2 _frm2;
    
        public Form1() {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += BwOnDoWork;
            bw.RunWorkerCompleted += BwOnRunWorkerCompleted;
            bw.RunWorkerAsync();
    
            _frm2 = new Form2(bw);
            _frm2.StartPosition = FormStartPosition.CenterParent;
            _frm2.ShowDialog();
        }
    
        private void BwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
           if (_frm2 != null)
           {
               _frm2.Close();
           }
        }
    
        private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var bw = sender as BackgroundWorker;
            var i = 0;
            while (i < 100 && !bw.CancellationPending)
            {
                bw.ReportProgress(i);
                Thread.Sleep(100);
                i++;
            }
        }
    }
    public partial class Form2 : Form
    {
        private BackgroundWorker _bw;
    
        public Form2() {
            InitializeComponent();
        }
    
        public Form2(BackgroundWorker bw) : this()
        {
            _bw = bw;
            _bw.ProgressChanged += BwOnProgressChanged;
        }
    
        private void BwOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            progressBar1.Value = progressChangedEventArgs.ProgressPercentage;
        }
    
        private void button1_Click(object sender, EventArgs e) {
            _bw.CancelAsync();
        }
    }
