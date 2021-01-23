    public partial class Form2 : Form
    {
        BackgroundWorker worker = new BackgroundWorker();
        public Form2()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            InitializeComponent();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalSteps = 5;
            for (int i = 1; i <= totalSteps; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(i);
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resultText.Text = "Worker complete";
            btnDoWork.Enabled = true;
            progressBar1.Visible = false;
        }
        private void btnDoWork_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            worker.RunWorkerAsync();
        }
    }
