    public async Task<string> SendRequestGetResponse(string postData, CookieContainer cookiesContainer = null)
    {
        var postRequest = (HttpWebRequest)WebRequest.Create(Constants.WebServiceUrl);
	    postRequest.ContentType = "Your content-type";
	    postRequest.Method = "POST";
	    postRequest.CookieContainer = new CookieContainer();
	    postRequest.CookieContainer = App.Session.Cookies;
	    using (var requestStream = await postRequest.GetRequestStreamAsync())
	    {
		    byte[] postDataArray = Encoding.UTF8.GetBytes(postData);
		    await requestStream.WriteAsync(postDataArray, 0, postDataArray.Length);
	    }
	
	    var postResponse = await postRequest.GetResponseAsync() as HttpWebResponse;
	    if (postResponse != null)
	    {
		    var postResponseStream = postResponse.GetResponseStream();
		    var postStreamReader = new StreamReader(postResponseStream);
		
		    // Can use cookies if you need
		    if (cookiesContainer == null)
		    {
			    if (!string.IsNullOrEmpty(postResponse.Headers["YourCookieHere"]))
			    {
				    var cookiesCollection = postResponse.Cookies;
				    // App.Session is a global object to store cookies and etc.
				    App.Session.Cookies.Add(new Uri(Constants.WebServiceUrl), cookiesCollection);
			    }
		    }
		    string response = await postStreamReader.ReadToEndAsync();
		    return response;
	    }
	    return null;
    }
