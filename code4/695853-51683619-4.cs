    // POST
    string SubmitData(string data)
    {
        string response;
        using (var wc = new WebClient())
        {
            wc.Headers["Content-type"] = "text/plain";
            response = wc.UploadString("https://data.mtgox.com/api/1/BTCUSD/trades", "POST", data);
        }
    
        return response;
    }
    // POST: easily url encode multiple parameters
    string SubmitForm(string project, string subject, string sender, string message)
    {
        // url encoded query
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("project", project);
        query.Add("subject", subject);
    
        // url encoded data
        NameValueCollection data = HttpUtility.ParseQueryString(string.Empty);
        data.Add("sender", sender);
        data.Add("message", message);
    
        string response;
        using (var wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            response = wc.UploadString( "https://data.mtgox.com/api/1/BTCUSD/trades?"+query.ToString()
                                      , WebRequestMethods.Http.Post
                                      , data.ToString()
                                      );
        }
    
        return response;
    }
