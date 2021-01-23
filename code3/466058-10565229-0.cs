    void Main()
    {
    	var task = MakeAsyncRequest("http://www.google.com", "text/html");
    	Console.WriteLine ("Got response of {0}", task.Result);
    }
    
    // Define other methods and classes here
    public static Task<string> MakeAsyncRequest(string url, string contentType)
    {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    	request.ContentType = contentType;
    	request.Method = WebRequestMethods.Http.Get;
    	request.Timeout = 20000;
    	request.Proxy = null;
    
    	Task<WebResponse> task = Task.Factory.FromAsync(
    		request.BeginGetResponse,
    		asyncResult => request.EndGetResponse(asyncResult),
    		(object)null);
    	
    	return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
    }
    
    private static string ReadStreamFromResponse(WebResponse response)
    {
    	using (Stream responseStream = response.GetResponseStream())
    	using (StreamReader sr = new StreamReader(responseStream))
    	{
    		//Need to return this response 
    		string strContent = sr.ReadToEnd();
    		return strContent;
    	}
    }
