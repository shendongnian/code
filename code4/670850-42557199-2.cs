    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int i = 0;
            if (!e.Cancelled)
            {
                i = (int)(e.Result);
            }
            else
            {
                i = 0;
            }
            // Check to see if an error occurred in the
            // background process.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                MessageBox.Show("Processing cancelled.");
                return;
            }
            // Everything completed normally.
            // process the response using e.Result
            MessageBox.Show("Processing is complete.");
        }
