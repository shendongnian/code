    HttpWebRequest myRequest = WebRequest.CreateHttp("http://yoururl);
    myRequest.Method = "GET";
    myRequest.BeginGetResponse(GetResponseCallback, myRequest);
    
    private void GetResponseCallback(IAsyncResult asynchronousResult)
    {
    	try
    	{
    		WebResponse resp = request.EndGetResponse(asynchronousResult);
    		HttpWebResponse response = (HttpWebResponse)resp;
    		Stream streamResponse = response.GetResponseStream();
    		StreamReader streamRead = new StreamReader(streamResponse);
    		string responseString = streamRead.ReadToEnd();
    		// Close the stream object
    		streamResponse.Close();
    		streamRead.Close();
    		// Release the HttpWebResponse
    		response.Close();
    		
    		//Do whatever you want with the returned "responseString"
    		Console.WriteLine(responseString);
    
    }
    	
