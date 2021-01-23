    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bgw.RunWorkerAsync();
            Task.Factory.StartNew(SomeMoreStuff);
        }
        private void SomeMoreStuff()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(50);
                this.Invoke((Action)HogTheUIThread);
            }
        }
        private void HogTheUIThread()
        {
            Thread.Sleep(1000);
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100); // Wait 100 milliseconds
                //Console.WriteLine(i);
                bgw.ReportProgress(i);
            }
        }
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update status label
            lblStatus.Text = e.ProgressPercentage.ToString();
        }
    }
