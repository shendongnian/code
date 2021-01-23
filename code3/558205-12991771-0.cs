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
             // Perform a time consuming operation 
             // And report progress via call to ReportProgress method        
        }
    
        // This event handler updates the progress. 
        private void backgroundWorker1_ProgressChanged(
                    object sender, ProgressChangedEventArgs e)
        {
            // Update UI status here
        }
    
        // This event handler deals with the results of the background operation. 
        private void backgroundWorker1_RunWorkerCompleted(
                    object sender, RunWorkerCompletedEventArgs e)
        {
            // Show message 'Woo Hoo, data was written'
        }
    }
