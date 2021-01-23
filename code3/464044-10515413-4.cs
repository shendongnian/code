    public string getStuff(string password)
    {
         string responseMessage = null;
         var request = WebRequest.Create("http://localhost/LoginService/LoginService.svc/getStuff/" + password) as HttpWebRequest;
        if (request != null)
        {
            request.ContentType = "application/json";      
            request.Method = "GET";
            var response = request.GetResponse() as HttpWebResponse;
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream responseStream = response.GetResponseStream();
                        if (responseStream != null)
                        {
                            var reader = new StreamReader(responseStream);
    
                            responseMessage = reader.ReadToEnd();                        
                        }
                    }
                    else
                    {
                        responseMessage = response.StatusDescription;
                    }
        }
        if (responseMessage == "Success")
        {
            return "Success";
        }
        else
        {
            return "Failure";
        }
    }
