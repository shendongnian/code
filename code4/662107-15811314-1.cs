    private void uxReadFileButton_Click(object sender, EventArgs e)
    {
        uxFileStatusLabel.Text = String.Empty;
        this.uxReadFileButton.Enabled = false;
        this.uxCancelReadingFileButton.Enabled = true;
        var clientList = ReadFile(uxFileNameBox.Text);
        BackGroundWorker bgw;
        foreach (var client in clientList)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += readFileBackgroundWorker_DoWork;
            //bgw.RunWorkerCompleted += 
            bgw.RunWorkerAsync(client);
        }
    }
    private void readFileBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        ProcessClient((ClientObject)e.Argument, worker, e);
    }
    private void ProcessClient(ClientObject client, BackgroundWorker worker, DoWorkEventArgs e)
    {
        try
        {
            client.FileClientDischarge(SystemCode, UserName, Password);
            int percent = (int)(Math.Ceiling(((double)(client.RecordNumber + 1) / 121) * 100));
            worker.ReportProgress(percent, client);
        }
        catch (Exception ex)
        {
            worker.CancelAsync();
        }
        e.Result = client.RecordNumber;
    }
