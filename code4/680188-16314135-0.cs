    public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        // Can remove (WebClient) cast, if dictionary is <object, ProgressBar>
        flowLayoutPanel1.Controls.Remove(dic[(WebClient)sender]);
        MessageBox.Show("Download Completed");
    }
    public void DownoadInProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        var progBar = dic[(WebClient)sender];
        progBar.Maximum = total_bytes;
        progBar.Value = (int)e.BytesReceived;                
    }
