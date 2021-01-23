    WebClient client = new WebClient ();
    Uri uri = new Uri(address);
    
    // Specify that the DownloadFileCallback method gets called
    // when the download completes.
    client.DownloadFileCompleted += new AsyncCompletedEventHandler (DownloadFileCallback2);
    // Specify a progress notification handler.
    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
    client.DownloadFileAsync (uri, "serverdata.txt");
    private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
    {
        // Displays the operation identifier, and the transfer progress.
        Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", 
            (string)e.UserState, 
            e.BytesReceived, 
            e.TotalBytesToReceive,
            e.ProgressPercentage);
    }
