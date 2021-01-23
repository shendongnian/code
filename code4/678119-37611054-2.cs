    public string SendGCMNotification(string apiKey, string deviceId, string postData)
    {
    	string postDataContentType = "application/json";
    	apiKey = "AIzaSyC13...PhtPvBj1Blihv_J4"; // hardcorded
    	deviceId = "da5azdfZ0hc:APA91bGM...t8uH"; // hardcorded
    
    	string message = "Your text";
    	string tickerText = "example test GCM";
    	string contentTitle = "content title GCM";
    	postData =
    	"{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
    	  "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
    				 "\"contentTitle\":\"" + contentTitle + "\", " +
    				 "\"message\": \"" + message + "\"}}";
    
    
    	ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
    
    	//
    	//  MESSAGE CONTENT
    	byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    	//
    	//  CREATE REQUEST
    	HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
    	Request.Method = "POST";
    	Request.KeepAlive = false;
    	Request.ContentType = postDataContentType;
    	Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
    	Request.ContentLength = byteArray.Length;
    
    	Stream dataStream = Request.GetRequestStream();
    	dataStream.Write(byteArray, 0, byteArray.Length);
    	dataStream.Close();
    
    	//
    	//  SEND MESSAGE
    	try
    	{
    		WebResponse Response = Request.GetResponse();
    		HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
    		if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
    		{
    			var text = "Unauthorized - need new token";
    		}
    		else if (!ResponseCode.Equals(HttpStatusCode.OK))
    		{
    			var text = "Response from web service isn't OK";
    		}
    
    		StreamReader Reader = new StreamReader(Response.GetResponseStream());
    		string responseLine = Reader.ReadToEnd();
    		Reader.Close();
    
    		return responseLine;
    	}
    	catch (Exception e)
    	{
    	}
    	return "error";
    }
    
    public static bool ValidateServerCertificate(
    object sender,
    X509Certificate certificate,
    X509Chain chain,
    SslPolicyErrors sslPolicyErrors)
    {
    	return true;
    }
