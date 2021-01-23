    void Download(){
        Web client = new WebClient();
        client.Credentials = new NetworkCredential(username, password);
        BackgroundWorker bg = new BackgroundWorker();
        bg.DoWork += (s, e) => { 
            client.DownloadFile("ftp://ftpsample.net/sample.zip", "sample.zip"); 
        };
        bg.RunWorkerCompleted += (s, e) => { //when download is completed
            MessageBox.Show("done downloading");
            download1.Enabled = true; //enable download button
            progressBar.Value = 0; // reset progressBar
        };
        bg.RunWorkerAsync();
        download1.Enabled = false; //disable download button 
        while (bg.IsBusy)
        {
            progressBar.Increment(1); //well just for extra/loading
            Application.DoEvents(); //processes all windows messages currently in the message queue
        }
    }
