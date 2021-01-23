    void btn_Submit_Click(object sender, EventArgs e)
    {
        btn_Submit.Enabled = false; // disable button while saving report       
        timer.Start();
        progressBar.Visible = true;       
        backgroundWorker.RunWorkerAsync();        
    }
    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // save report here
    }
    
    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        btn_Submit.Enabled = true; // enable button
        timer.Stop();
        progressBar.Visible = false;   
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
        if (progressBar.Value == progressBar.Maximum)
        {
            progressBar.Value = progressBar.Minimum;
            return;
        }
 
        progressBar.PerformStep();
    }
