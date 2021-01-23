    void btn_Submit_Click(object sender, EventArgs e)
    {
        btn_Submit.Enabled = false; // disable button while saving report        
        lbl_Status.Text = "Please wait..";        
        backgroundWorker.RunWorkerAsync();
    }
    
    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // save report here
    }
    
    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        btn_Submit.Enabled = true; // enable button
        lbl_Status.Text = "Report saved";
    }
