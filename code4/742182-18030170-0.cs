        public partial class Form1 : Form
    {
       
        BackgroundWorker bgw = new BackgroundWorker();      
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
          
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
               
        private void btn_generate_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            bgw.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           int total = 100; //some number (this is your variable to change)!!
            
            for (int i = 0; i <= total; i++) //some number (total)
            {
                System.Threading.Thread.Sleep(10);
                int percents = (i * 100) / 100;
                bgw.ReportProgress(percents, i);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            if (e.ProgressPercentage == 100)
            {
                label3.Text = String.Format("Generated.. {0} %", e.ProgressPercentage);
            }
           // label2.Text = String.Format("Total items transfered: {0}", e.UserState);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }
    }`
