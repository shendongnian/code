    private void getInfoButton_Click(object sender, EventArgs e)
    {
        progressBar1.Style = ProgressBarStyle.Marquee;
        getInfoButton.Enabled = false;
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        bw.RunWorkerAsync("URI Here");
    }
    
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
            WebClient client = new WebClient();
            StreamReader reader = new StreamReader(client.OpenRead(e.Argument));
            e.Result = reader;
    }
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        StreamReader reader = (StreamReader)e.Result;
        while ((line = reader.ReadLine()) != null) {
            // Do stuff
        }
        progressBar1.Style = ProgressBarStyle.Continuous;
        getInfoButton.Enabled = true;
    }
