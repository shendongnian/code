    HttpWebRequest request = WebRequest.Create(stringBuilder.ToString()) as HttpWebRequest; 
    request.ContentType = "application/json; charset=utf-8"; 
    request.Credentials = CredentialCache.DefaultCredentials; 
    try
    {
    	response = (HttpWebResponse)request.GetResponse(); 
    	
    	// perform normal processing
    }
    catch(WebException ex)
    {
    	// are you sure you just want to swallow the exception like this?
    	continue;
    }
     
