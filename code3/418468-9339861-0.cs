    public const string userAgent = "Mozilla/5.0 (Windows NT 6.1; rv:7.0.1) Gecko/20100101 Firefox/7.0.1";
    public CookieContainer cookieJar;
    private void Login_Click(object sender, EventArgs e)
    {
    	cookieJar = Login();
    }
    private CookieContainer Login()
    {
    	string username = txtUsername.Text;
    	string password = txtPassword.Text;
    	// Create a request using the provied URL. 
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginPageURL);
 
    	// Set the Method property of the request to POST.
    	request.Method = "POST";
    	
    	// Set the Cookiecontainer
    	CookieContainer cookieJar = new CookieContainer();
    	request.CookieContainer = cookieJar;
                
    	// Create POST data and convert it to a byte array.
    	string postData = "username=" + username + "&password=" + password;
    	byte[] byteArray = Encoding.UTF8.GetBytes (postData);
	
    	// Set the ContentType property of the WebRequest.
    	request.ContentType = "application/x-www-form-urlencoded";
			
    	// Set the User Agent
    	request.UserAgent = userAgent;
		                
    	// Set the ContentLength property of the WebRequest.
    	request.ContentLength = byteArray.Length;
    	// Get the request stream.
    	Stream dataStream = request.GetRequestStream ();
    	// Write the data to the request stream.
    	dataStream.Write (byteArray, 0, byteArray.Length);
    	// Close the Stream object.
    	dataStream.Close ();
    	// Get the response.
    	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    	// Get the stream containing content returned by the server.
    	dataStream = response.GetResponseStream ();
    	// Open the stream using a StreamReader for easy access.
    	StreamReader reader = new StreamReader (dataStream);
	
    	// Read the content.
    	string responseFromServer = reader.ReadToEnd ();
                
    	string cookie = cookieJar.GetCookieHeader(request.RequestUri);
    	// Clean up the streams.
    	reader.Close();
    	dataStream.Close();
    	response.Close();
    	return cookieJar;
    }
    private void viewPage(CookieContainer cookieJar, string pageURL)
    { 
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageURL);
    	// Set the ContentType property of the WebRequest.
    	request.ContentType = "application/x-www-form-urlencoded";
    	// Set the Method property of the request to POST.
    	request.Method = "POST";
    	// Set the User Agent
    	request.UserAgent = userAgent;
    	// Put session back into CookieContainer
    	request.CookieContainer = cookieJar;
    	// Get the request stream.
    	Stream dataStream = request.GetRequestStream();
    	// Close the Stream object.
    	dataStream.Close();
    	// Get the response.
    	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    	// Get the stream containing content returned by the server.
    	dataStream = response.GetResponseStream();
    	// Open the stream using a StreamReader for easy access.
    	StreamReader reader = new StreamReader(dataStream);
    	// Read the content.
    	string responseFromServer = reader.ReadToEnd();
    }
