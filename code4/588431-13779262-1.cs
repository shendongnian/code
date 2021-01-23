    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            button.Visible = true; 
        }
    }
