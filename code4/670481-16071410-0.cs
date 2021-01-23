    private Stopwatch _sw;
    
    public void DownloadFile(string url, string fileName)
    {
        string path = @"C:\DL\";
    
        Thread bgThread = new Thread(() =>
        {
    
            _sw = new Stopwatch();
            _sw.Start();
            labelDownloadAudioStatusText.Visibility = Visibility.Visible;
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileCompleted +=
                    new AsyncCompletedEventHandler(DownloadCompleted);
                webClient.DownloadProgressChanged +=
                    new DownloadProgressChangedEventHandler(DownloadStatusChanged);
                webClient.DownloadFileAsync(new Uri(url), path + fileName);
            }
        });
    
        bgThread.Start();
    }
    
    void DownloadStatusChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        Dispatcher.BeginInvoke((MethodInvoker) delegate
        {
            int percent = 0;
            if (e.ProgressPercentage != percent)
            {
                percent = e.ProgressPercentage;
                progressBarDownloadAudio.Value = percent;
    
                labelDownloadAudioProgress.Content = percent + "%";
                labelDownloadAudioDlRate.Content =
                    (Convert.ToDouble(e.BytesReceived)/1024/
                    _sw.Elapsed.TotalSeconds).ToString("0.00") + " kb/s";
    
                Thread.Sleep(50);
            }
        });
    }
    
    private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
        Dispatcher.BeginInvoke((MethodInvoker) delegate
        {
    
            labelDownloadAudioDlRate.Content = "0 kb/s";
            labelDownloadAudioStatusText.Visibility = Visibility.Hidden;
        });
    }
