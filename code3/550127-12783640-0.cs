    public partial class Form1 : Form
    {
        BackgroundWorker bgw;
        public Form1()
        {
            InitializeComponent();
            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.WorkerReportsProgress = true;
        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string text = (string)e.UserState;
            SetValue(text);//or do whatever you want with the received data
        }
        void SetValue(string text)
        {
            this.label1.Text = text;
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                string text = "Value is " + i.ToString();
                bgw.ReportProgress(1, text);
                Thread.Sleep(1000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bgw.RunWorkerAsync();
        }
}
