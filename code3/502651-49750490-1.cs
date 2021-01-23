    DateTime _startedAt;
    
    WebClient webClient = new WebClient();
        
    webClient.DownloadProgressChanged += OnDownloadProgressChanged;
    
    webClient.DownloadFileAsync(new Uri("Download URL"), "Download Path")
        
    private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
    	if (_startedAt == default(DateTime))
    	{
    		_startedAt = DateTime.Now;
    	}
    	else
    	{
    		var timeSpan = DateTime.Now - _startedAt;
    		if (timeSpan.TotalSeconds > 0)
    		{
    			var bytesPerSecond = e.BytesReceived / (int) timeSpan.TotalSeconds;
    		}
    	}
    }
