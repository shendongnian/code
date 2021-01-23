    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }
    
        private void WriteDataButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
             for (int i = 1; i <= numberOfIterations; i++)
             {
                  // write part of data
                  (sender as BackgroundWorker).ReportProgress(i * 100 / numberOfIterations);
             }    
        }
    
        // This event handler updates the progress. 
        private void backgroundWorker1_ProgressChanged(
                    object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    
        // This event handler deals with the results of the background operation. 
        private void backgroundWorker1_RunWorkerCompleted(
                    object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Huge data was written");
        }
    }
