    private HttpWebRequest CreateHttpWebRequest<U>(string userSessionID, string method, string fullUrl, U uploadData)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(fullUrl);
        req.Method = method; // GET PUT POST DELETE
        req.ConnectionGroupName = userSessionID;  // We make separate connection-groups for each user session. Within a group connections can be reused.
        req.ServicePoint.ConnectionLimit = 10;    // The default value of 2 within a ConnectionGroup caused me always a "Timeout exception" because a user's 1-3 concurrent WebRequests within a second.
        req.ServicePoint.MaxIdleTime = 5 * 1000;  // (5 sec) default was 100000 (100 sec).  Max idle time for a connection within a ConnectionGroup for reuse before closing
        Log("Statistics: The sum of connections of all connectiongroups within the ServicePoint: " + req.ServicePoint.CurrentConnections; // just for statistics
    
        if (uploadData != null)
        {
            req.ContentType = "application/json";
            SerializeToJson(uploadData, req.GetRequestStream());
        }
        return req;
    }
        
    /// <summary>Serializes and writes obj to the requestStream and closes the stream. Uses JSON serialization from System.Runtime.Serialization.</summary>        
    public void SerializeToJson(object obj, Stream requestStream)
    {
        DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
        json.WriteObject(requestStream, obj);            
        requestStream.Close();
    }
