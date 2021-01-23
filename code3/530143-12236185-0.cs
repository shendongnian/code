        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                   CheckPrintingStatus();
                   CheckFileStatus();
                   CheckImportStatus();
                   CheckArchiverStatus();
                   System.Threading.Thread.Sleep(5000); // sleep for 5 seconds
                }
            }
        }
