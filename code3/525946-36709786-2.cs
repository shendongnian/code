    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
	        public Form1()
	        {
	            InitializeComponent();
	        }
	        private void Form1_Load(object sender, System.EventArgs e)
	        {
	            // Start the BackgroundWorker.
	            backgroundWorker1.RunWorkerAsync();
	        }
	        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	        {
	            for (int i = 1; i <= 100; i++)
	            {
		            // Wait 100 milliseconds.
		            Thread.Sleep(100);
		            // Report progress.
		            backgroundWorker1.ReportProgress(i);
                }
	        }
	        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	        {
	            // Change the value of the ProgressBar to the BackgroundWorker progress.
	            progressBar1.Value = e.ProgressPercentage;
	            // Set the text.
	            this.Text = e.ProgressPercentage.ToString();
	        }
        }
    } //closing here
