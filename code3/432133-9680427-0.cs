    WebClient webClient = new WebClient();
    webClient.DownloadProgressChanged += (s, args) =>
    {
    	//args.BytesReceived, args.TotalBytesToReceive and args.ProgressPercentage will have all you need
    };
    webClient.DownloadFileCompleted += (s, args) =>
    {
    	//done
    };
    webClient.DownloadFileAsync(new Uri(remoteFile), localFile);
