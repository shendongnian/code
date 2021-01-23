    private void button1_Click(object sender, EventArgs e)
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.RunWorkerCompleted += BwOnRunWorkerCompleted;
        bw.DoWork += BwOnDoWork;
        bw.RunWorkerAsync();
    }
    
    private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        MessageBox.Show("This is a message from a background thread");
    }
    
    private void BwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
    {
        MessageBox.Show("Your done");
    }
