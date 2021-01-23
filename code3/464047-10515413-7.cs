    public string getStuff(string password)
    {
        // NOTE: Below 2 lines to acccess the login service via SOAP 
        // assuming that you have added a service reference to your project and added the needed config entries in you androidservice config file
        LoginServiceClient client = new LoginServiceClient(binding, address);
        return client.getStuff(password);
         // NOTE: Below code to access it RESTfully 
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
