    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker w = new BackgroundWorker();
            w.WorkerReportsProgress = true;
            w.DoWork += new DoWorkEventHandler(w_DoWork);
            w.ProgressChanged += new ProgressChangedEventHandler(w_ProgressChanged);
            w.RunWorkerCompleted += new RunWorkerCompletedEventHandler(w_RunWorkerCompleted);
            w.RunWorkerAsync();
            button1.Text = "Started";
        }
        void w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Text = "Job is done";
        }
        void w_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button1.Text = e.ProgressPercentage.ToString();
        }
        void w_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
                worker.ReportProgress(10 * i);
            }
        }
    }
