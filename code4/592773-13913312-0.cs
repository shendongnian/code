    public static string PostMessageToURL(string url, string parameters)
    {
    	using (WebClient wc = new WebClient())
    	{
    		wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
    		string HtmlResult = wc.UploadString(url,"POST", parameters);
    		return HtmlResult;
    	}
    }
