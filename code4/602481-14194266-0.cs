    private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
         progressBar.Max = (int)e.TotalBytesToReceive;
        progressBar.Value = (int)e.BytesReceived;
    
    }
