    IPNData GetIPNData()
    {
    	var ipnData = new IPNData();
    	var param = Request.BinaryRead(HttpContext.Request.ContentLength);
    	var ipnStr = Encoding.ASCII.GetString(param);
    	ipnData.Args = HttpUtility.ParseQueryString(ipnStr);
    	
        // Return the ipn string to paypal for validation
        ipnStr += "&cmd=_notify-validate";
    	var request = (HttpWebRequest)WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
    	request.Method = "POST";
    	request.ContentType = "application/x-www-form-urlencoded";
    	request.ContentLength = strRequest.Length;
    
    	using (var sw = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
    	{
    		sw.Write(ipnStr);
    	}
    
    	using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
    	{
            // Response should be "VERIFIED"
    		ipnData.Response = sr.ReadToEnd();
    	}
    
    	return ipnData;
    }
