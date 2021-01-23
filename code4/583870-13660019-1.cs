    public partial class Form1 : Form
    {
        BackgroundWorker worker = null;
        Rectangle rect = new Rectangle(0, 0, 100, 100);
    
        public Form1()
        {
            InitializeComponent();
    
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
    
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                rect.Y = i;
                System.Threading.Thread.Sleep(100);
                worker.ReportProgress(i);
            }
    
        }
    
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ProgressChangedEventHandler(worker_ProgressChanged), new object[] { sender, e });
                return;
            }
    
            this.Refresh();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
    
            e.Graphics.DrawRectangle(SystemPens.ActiveBorder, rect);
        }
    }
