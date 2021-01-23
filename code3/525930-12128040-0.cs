    private void bParsePosts_Click(object sender, EventArgs e)
    {
        parseWorker.WorkerReportsProgress = true;
        parseWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        parseWorker.RunWorkerAsync();
    }
    private void parseWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Loop through each item
        for (int i = 0; i < lvPostQueue.Items.Count; i++)
        {
            string title = lvPostQueue.Items[i].SubItems[0].ToString();
            string category = lvPostQueue.Items[i].SubItems[1].ToString();
            string url = lvPostQueue.Items[i].SubItems[2].ToString();
    
            parseWorker.ReportProgress(i * 100 / lvPostQueue.Items.Count, i);
        }
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var i = (int)e.UserState;
        lvPostQueue.Items[i].SubItems[3].Text = "Done";
    }
