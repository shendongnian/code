    void GetResponseCallback(IAsyncResult asynchronousResult) 
    {
    	Dispatcher.BeginInvoke(() =>
    	{
    		MessageBox.Show("Done");
    	});
    
    }
    
    void getWeb() {
    	Thread.Sleep(1000);
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
    	request.Method = "GET";
    	request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }
    
    new Thread(getWeb).Start(); //Start a new thread
       
