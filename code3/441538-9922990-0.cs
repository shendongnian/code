    void GetRequestStreamCallbackx(IAsyncResult asynchronousResult)
    {
        HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
        // End the stream request operation
        Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);
        string img = string.Empty;
        try
        {
            img = Convert.ToBase64String(imageBytes);
        }
        catch { }
        // Create the post data
        // string postData = "";
        var json = "";
    
        Dispatcher.BeginInvoke(() =>
        {
            json = "{\"emailID\": " + txtemail.Text.Trim() + ",\"pwd\": " + txtpassword.Text + ",\"name\":" + txtname.Text + ",\"img\": " + img + "}";
    
    
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
    
            // Add the post data to the web request
            try
            {
                postStream.Write(byteArray, 0, byteArray.Length);
            }
            catch { }
            postStream.Close();
    
            // Start the web request
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        });
    }
