    public void InstallSecuniaPSI()
    {
    	var source = new Uri("http://www.webserver.com:8014/psisetup.exe");
    	var dest = Path.Combine(Path.GetTemp(), "Download_SecuniaPSI.exe");
    
    	var client = new WebClient();
    	client.DownloadProgressChanged += OnDownloadProgressChanged;
    	client.DownloadFileCompleted += OnDownloadComplete;
    	client.DownloadFileAsync(source, dest, dest);	
    }
    
    private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
    	// report progress
        Console.WriteLine("'{0}' downloaded {1} of {2} bytes. {3}% complete"(string)e.UserState, e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
    }
    
    private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
    {
    	// clean up
    	var client = (WebClient)sender;
    	client.DownloadProgressChanged -= OnDownloadProgressChanged;
    	client.DownloadFileCompleted -= OnDownloadComplete;
    	
    	if (e.Error != null)
            throw e.Error;
    
    	if (e.Cancelled)
    	    Environment.Exit(1);
    		
    	// install program
    	var downloadedFile = (string)e.UserState;
    	var processInfo = new ProcessStartInfo(downloadedFile, "/S");
    	processInfo.CreateNoWindow = true;
    	
    	var installProcess = Process.Start(processInfo);
    	installProcess.WaitForExit();
        
        Environment.Exit(installProcess.ExitCode);
    }
