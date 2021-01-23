    //preAuth the request
    // You can add logic so that you only pre-authenticate the very first request.
    // You should not have to pre-authenticate each request.
    WRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
    // Set the username and the password.
    WRequest.Credentials = new NetworkCredential(user, password);
    WRequest.PreAuthenticate = true;
    WRequest.UserAgent = "Upload Test";
    WRequest.Method = "HEAD";
    WRequest.Timeout = 10000;
    WResponse = (HttpWebResponse)WRequest.GetResponse(); 
    WResponse.Close();
    // Make the real request.
