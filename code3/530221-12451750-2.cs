    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;
        bool connected = false;
        string url = "https://www.google.com/";
        while (!worker.CancellationPending)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 15000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                connected = (response.StatusCode == HttpStatusCode.OK);
                backgroundWorker1.ReportProgress(10, connected);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                e.Cancel = true;
                e.Result = "cancelled";
                
                //return false;
            }
        }
        e.Result = connected;
    }
    
    private void backgroundWorker1_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
        this.tbResult.Text = e.ProgressPercentage.ToString();
        System.Diagnostics.Debug.WriteLine(e.UserState.ToString());
    }
