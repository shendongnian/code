    private void startDownload()
    {
        Thread bgThead = new Thread(() => {
               WebClient client = new WebClient();
              client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
              client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
              client.DownloadFileAsync(new Uri("http://joshua-ferrara.com/luahelper/lua.syn"), @"C:\LUAHelper\Syntax Files\lua.syn");
        }
        bgThread.Start();
    }
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        this.BeginInvoke((MethodInvoker) delegate {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            label2.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        });
    }
    void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.BeginInvoke((MethodInvoker) delegate {
             label2.Text = "Completed";
        });
    }
