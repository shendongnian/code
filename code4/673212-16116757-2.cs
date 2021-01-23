        public partial class Form1 : Form
        {
            BackgroundWorker backgroundWorker;
    
            public Form1()
            {
                InitializeComponent();
                backgroundWorker = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
    
                backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
                backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
                
            }
    
            void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                    lblStatus.Text = "Task Cancelled.";
                else if (e.Error != null)
                    lblStatus.Text = "Error - " + e.Error.Message;
                else
                    lblStatus.Text = "Task Completed...";
    
                btnStartAsyncOperation.Enabled = true;
                btnCancel.Enabled = false;
            }
    
            void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = e.ProgressPercentage;
                lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
            }
    
            void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    backgroundWorker.ReportProgress(i);
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker.ReportProgress(0);
                        return;
                    }
                }
                backgroundWorker.ReportProgress(100);
            }
    
            private void btnStartAsyncOperation_Click(object sender, EventArgs e)
            {
                btnStartAsyncOperation.Enabled = false;
                btnCancel.Enabled = true;
                backgroundWorker.RunWorkerAsync();
            }
    
            private void btnCancel_Click(object sender, EventArgs e)
            {
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
            }
        }
