    WebClient client = new WebClient(); 
    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback); 
    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallBack2);
    backgroundWorker1.RunWorkerAsync(client); 
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)   
    {   
        WebClient client = (WebClient)e.Argument;   
        client.DownloadFile(textBox1.Text, @"D:\test\test.zip");   
   
    }   
