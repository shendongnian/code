    public void makeQRest()
            {
                try
                {
                    string auth = "http://" + Config.jsaIP + "/api/hornet-q/queues/";
    
                    string body = "<queue name='deleteq'><durable>false</durable></queue>";
                
                    IWebCredentials credentials = new Hammock.Authentication.Basic.BasicAuthCredentials
                    {
                        Username = Config.uName,
                        Password = Config.pWord
    
                    };
    
                    RestClient client = new RestClient
                    {
                        Authority = auth,
                    };
                    client.AddHeader("content-type", "application/hornetq.jms.queue+xml");
    
    
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
