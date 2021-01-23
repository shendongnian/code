    HttpWebRequest webRequest = WebRequest.Create(@"https://www.somedomain.com/etc") as HttpWebRequest;
    webRequest.ContentType = @"application/x-www-form-urlencoded";
    webRequest.Method = "POST";
    // Prepare the post data into a byte array
    string formValues = string.Format(@"login={0}&password={1}", "someLogin", "somePassword");
    byte[] byteArray = Encoding.UTF8.GetBytes(formValues);
    // Set the "content-length" header 
    webRequest.Headers["Content-Length"] = byteArray.Length.ToString();
    // Write POST data
    IAsyncResult ar = webRequest.BeginGetRequestStream((ac) => { }, null);
    using (Stream requestStream = webRequest.EndGetRequestStream(ar) as Stream)
    {
        requestStream.Write(byteArray, 0, byteArray.Length);
        requestStream.Close();
    }
   
    // Retrieve the response
    string responseContent;    
   
    ar = webRequest.BeginGetResponse((ac) => { }, null);
    WebResponse webResponse = webRequest.EndGetResponse(ar) as HttpWebResponse;
    try
    {
        // do something with the response ...
        using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
        {
            responseContent = sr.ReadToEnd();
            sr.Close();
        }
    }
    finally
    {
        webResponse.Close();
    }
