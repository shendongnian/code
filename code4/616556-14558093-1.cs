    bool authorized = false;
    bool navigated;
    WebBrowser objWebBrowser = new WebBrowser();
    void GetResults(string url)
    {
    	if(!authorized)
    	{
    		NavigateAndBlockWithSpinLock("http://www.website.com/login.php?user=xxx&pass=xxx");
    		authorized = true;
    	}
        objWebBrowser.Navigate(url);
    }
    
    void NavigateAndBlockWithSpinLock(string url)
    {
    	navigated = false;
    	
    	objWebBrowser.DocumentCompleted += NavigateDone;
    	
    	objWebBrowser.Navigate(url);
    	
    	int count = 0;
    	while(!navigated && count++ < 10)
    		Thread.Sleep(1000);
    		
    	objWebBrowser.DocumentCompleted -= NavigateDone;
    	
    	if(!navigated)
    		throw new Exception("fail");
    }
    
    void NavigateDone(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	navigated = true;
    }
    
    void objWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	if(authorized)
    	{
    		WebBrowser objWebBrowser = (WebBrowser)sender;
    		String data = new StreamReader(objWebBrowser.DocumentStream).ReadToEnd();
    	}
    }
