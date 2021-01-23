    // I do not know how you create the byteArray
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    // but you need to send a string
    string strRequest = Encoding.ASCII.GetString(byteArray);
    
    WebRequest request = WebRequest.Create("https://oauth.live.com/token");
    request.ContentType = "application/x-www-form-urlencoded";
    
    // not the byte length, but the string
    //request.ContentLength = byteArray.Length;
    request.ContentLength = strRequest.Length;
    
    request.Method = "POST"; 
    
    using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
    {
    	streamOut.Write(strRequest);
    	streamOut.Close();
    }
    
    string strResponse;
    // get the response
    using (StreamReader stIn = new StreamReader(request.GetResponse().GetResponseStream()))
    {
    	strResponse = stIn.ReadToEnd();
    	stIn.Close();
    }
    
    // and here is the results
    FullReturnLine = HttpContext.Current.Server.UrlDecode(strResponse);
