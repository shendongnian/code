    private void backgroundWorker1_DoWork(object sender,
                DoWorkEventArgs e)
            {
                // Get the BackgroundWorker that raised this event.
                BackgroundWorker worker = sender as BackgroundWorker;
    
                string connected = "not connected";
                string url = "https://www.google.com/";
    
                while (!worker.CancellationPending)
                {
                    try
                    {
                        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                        request.Timeout = 15000;
                        request.Credentials = CredentialCache.DefaultNetworkCredentials;
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    
                        if (response.StatusCode == HttpStatusCode.OK)  connected = "connected"; else connected = "Not Connected";
                        backgroundWorker1.ReportProgress(10, connected);
                        Thread.Sleep(1000);
                        // connected response.StatusCode == HttpStatusCode.OK ? "Connected" : "Not Connected";
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
