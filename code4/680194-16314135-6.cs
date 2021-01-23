    public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        // Can remove (WebClient) cast, if dictionary is <object, ProgressBar>
        var request = (WebClient)sender;
        flowLayoutPanel1.Controls.Remove(dic[request]);
        dic.Remove(request);
        MessageBox.Show("Download Completed");
    }
    public void DownoadInProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        var progBar = dic[(WebClient)sender];
        progBar.Value = e.ProgressPercentage;                
    }
