    public void DownloadFile(string _URL, string _SaveAs)
    	{
    	    try
    	    {
    	        System.Net.WebClient _WebClient = new System.Net.WebClient();
    	        // Downloads the resource with the specified URI to a local file.
    	        _WebClient.DownloadFile(_URL, _SaveAs);
    	    }
    	    catch (Exception _Exception)
    	    {
    	        // Error
    	        Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
    	    }
    	}
