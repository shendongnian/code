    private void XYZ_button_Click(object sender, EventArgs e)
    {
        /* Check no background workers are already running */
        if ((XYZ_backgroundworker.IsBusy != true) &&
            (PQR_backgroundworker.IsBusy != true))
        {
            XYZ.RunWorkerAsync();
        }
    }
    
    private void XYZ_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null) MessageBox.Show("Error: " + e.Error.Message);
        else if (e.Cancelled == true) MessageBox.Show("Canceled!");
    }
    
    private void XYZ_DoWork(object sender, DoWorkEventArgs e)
    {
        //Your code here
    }
