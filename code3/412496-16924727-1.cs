            [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            [OperationContractAttribute]
            public Stream AuthenticateFacebook(string facebookUserId, string token)
            {
                var json = new WebClient().DownloadString(string.Format("https://graph.facebook.com/me?access_token={0}", token));
    
                JObject parsedJson = JObject.Parse(json);
    
                //Ensure that there isn't a random Facebook server error
                if (parsedJson["error"] != null)
                {
                    throw new FaultException("Error parsing Facebook token.");
                }
    
                //Ensure the facebook user ID passed in via the client matches the one received from the server.
                if (Convert.ToString(parsedJson["id"]) != facebookUserId)
                {
                    throw new FaultException("Facebook login ids do not match. Something fishy is going on...");
                }
    
                //Now you know you have a valid facebook login id. Do your database stuff or whatever else here.
    
    
            }
