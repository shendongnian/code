    public partial class Form1 : Form
        {
            BackgroundWorker createAndSaveAMatchBGW;
            public Form1()
            {
                InitializeComponent();
                createAndSaveAMatchBGW = new BackgroundWorker();
                createAndSaveAMatchBGW.DoWork += new DoWorkEventHandler(createAndSaveAMatchBGW_DoWork);
                createAndSaveAMatchBGW.ProgressChanged += new ProgressChangedEventHandler(createAndSaveAMatchBGW_ProgressChanged);
                createAndSaveAMatchBGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(createAndSaveAMatchBGW_RunWorkerCompleted);
                createAndSaveAMatchBGW.WorkerReportsProgress = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                createAndSaveAMatchBGW.RunWorkerAsync(DateTime.Now);
            }
    
            void createAndSaveAMatchBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                MessageBox.Show("BackgroundWorker finished");
            }
    
            void createAndSaveAMatchBGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                label1.Text = ((DateTime)e.UserState).ToString("ss");
            }
    
            void createAndSaveAMatchBGW_DoWork(object sender, DoWorkEventArgs e)
            {
                //BackgroundWorker does something for a 10 seconds, each second it Reports
                BackgroundWorker bgw = (BackgroundWorker)sender;
                DateTime dt = (DateTime) e.Argument;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    dt = dt.AddSeconds(1);
                    bgw.ReportProgress(0, dt);
                }
            }
        }
