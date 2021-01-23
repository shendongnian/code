        [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string ParseAuthenticate( string strUsername, string strPassword)
    {
        
        string url = "https://api.parse.com/1/login?username=" + HttpUtility.UrlEncode(strUsername) + "&password=" + HttpUtility.UrlEncode(strPassword);
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        
        //pass basic authentication credentials
        httpWebRequest.Credentials = new NetworkCredential("My Parse App Id", "My Parse REST API Key");
        httpWebRequest.Method = "GET";
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            //Now you have your response.
            //or false depending on information in the response
            // return true;
            return responseText;
        }
    }
    }
