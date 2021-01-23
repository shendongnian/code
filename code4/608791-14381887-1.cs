    try
    {
    	HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Program.NotificationUrl);
    	request.KeepAlive = false;
    	request.Method = "Post";
    	request.ContentType = "text/xml";
    	request.Credentials = new System.Net.NetworkCredential(Program.NotificationUser, Program.NotificationPassword);
    
    	byte[] data = Encoding.UTF8.GetBytes(msg);
    
    	request.ContentLength = data.Length;
    	Stream reqStream = request.GetRequestStream();
    	reqStream.Write(data, 0, data.Length);
    	reqStream.Close();
    
    	WebResponse response = request.GetResponse();
    	using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    	{
    			reader.ReadToEnd();
    	}
    
    }
    catch (Exception) 
