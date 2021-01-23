    var webClient = new WebClient();
    var pb = new ProgressBar();
    pb.Maximum = 100;
    flowLayoutPanel1.Controls.Add(pb);
    
    webClient.DownloadProgressChanged += (o, args) =>
    {
        pb.Value = args.ProgressPercentage;
    };
    
    webClient.DownloadFileCompleted += (o, args) =>
    {
        flowLayoutPanel1.Controls.Remove(pb);
    };
    webClient.DownloadFileAsync(new Uri(this.uri), localPath);
