    public string GetDaysValueChange(string symbol)
    {
    	// Set the return string to null.
    	string result = null;            
    	try
    	{
    		// Use Yahoo finance service to download stock data from Yahoo
    		//  Note that f=w1 tells the service we just want the Days Value Change
    		string yahooURL = @"http://download.finance.yahoo.com/d/quotes.csv?s=" + 
    						  symbol + "&f=w1";
    
    		// Initialize a new WebRequest.
    		HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(yahooURL);
    		// Get the response from the Internet resource.
    		HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
    		// Read the body of the response from the server.
    		StreamReader strm = 
    		  new StreamReader(webresp.GetResponseStream(), Encoding.ASCII);
    
    		result = strm.ReadLine().Replace("\"", "");
    		strm.Close();
    	}
    	catch
    	{
    		// Handle exceptions.
    	}
    	// Return the stock quote data in XML format.
    	return result;
    }
