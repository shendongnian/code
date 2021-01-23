    IPNData GetIPNData()
    {
    	var ipnData = new IPNData();
    	var param = Request.BinaryRead(HttpContext.Request.ContentLength);
    	var strRequest = Encoding.ASCII.GetString(param);
    	ipnData.Args = HttpUtility.ParseQueryString(strRequest);
    	strRequest += "&cmd=_notify-validate";
    
    	var request = (HttpWebRequest)WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
    	request.Method = "POST";
    	request.ContentType = "application/x-www-form-urlencoded";
    	request.ContentLength = strRequest.Length;
    
    	// Verify the collected data
    	using (var sw = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
    	{
    		sw.Write(strRequest);
    	}
    
    	using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
    	{
    		ipnData.Response = sr.ReadToEnd();
    	}
    
    	return ipnData;
    }
