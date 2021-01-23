    public string SendRequest(WebRequestModel requestModel)
    {
        var request = WebRequest.Create(uri);
        var encoding = new UTF8Encoding();
        var requestData = encoding.GetBytes(requestModel.POSTData);
        
        request.ContentType = requestModel.ContentType;
        
        request.Method = WebRequestMethods.Http.Post;
        request.Timeout = (300 * 1000); 
        request.ContentLength = requestData.Length;
        // add your header value here
        //request.Headers["myheader"] = "";
        
        using (var stream = request.GetRequestStream())
        {
              stream.Write(requestData, 0, requestData.Length);
        }
        response = request.GetResponse();
        
        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }
