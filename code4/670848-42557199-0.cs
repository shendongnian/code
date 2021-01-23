    private void btnStart_Click(object sender, EventArgs e)
        {
            //BGW
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            
            
        }
