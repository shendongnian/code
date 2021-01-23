    bgw = new BackgroundWorker();
    bgw.WorkerReportsProgress = true;
    //bgw.WorkerSupportsCancellation = true;
    bgw.DoWork += bgw_DoWork;
    bgw.ProgressChanged += bgw_ProgressChanged;
    bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
/
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = openSingleFile.FileName;
            bgw.RunWorkerAsync(fileName);
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = (string)e.Argument;
            processFile(fileName);
        }
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int Progress = e.ProgressPercentage;
            //Update progressbar here
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Job completed
        }
