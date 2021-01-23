    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
    
        for (int i = 1; (i <= 10); i++)
        {
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // **Perform your uploads here** and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress((i * 10));
            }
        }
    }
