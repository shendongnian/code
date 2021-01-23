    private void button1_Click(object sender, EventArgs e)
    {
        worker.RunWorkerAsync();
    }
    static BackgroundWorker worker = new BackgroundWorker();
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        if (this.InvokeRequired)
            this.Invoke(new Action(()=>Refresh()));
    }
