    public void makeQRest()
            {
                try
                {
                    string auth = "http://wit.istc.cnr.it/stlab-tools/fred/api";
    
                    string body = "text=Miles Davis was an american jazz musician";
                
                    IWebCredentials credentials = new Hammock.Authentication.Basic.BasicAuthCredentials
                    {
                        Username = Config.uName,
                        Password = Config.pWord
    
                    };
    
                    RestClient client = new RestClient
                    {
                        Authority = auth,
                    };
                    client.AddHeader("content-type", "Accept: image/png");
    
    
                    RestRequest request = new RestRequest
                    {
    
                        Credentials = credentials,
                        Method = WebMethod.Post
                       };
                    request.AddPostContent(Encoding.UTF8.GetBytes(body));
                   
                    RestResponse response = client.Request(request);
                    Console.WriteLine("the create Queue status is " + response.StatusCode);
                    Console.WriteLine(response.Content);
                    Console.ReadLine();
                }  // end try
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
    
              
            }// End Method makeQRest()
