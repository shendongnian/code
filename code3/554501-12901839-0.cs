    Task.Factory.StartNew(()=>StartServer());
    Thread.Yield();
    StartClient();
----
    void StartServer()
    {
        Uri baseAddress = new Uri("http://localhost:8080/test");
        WebServiceHost host = new WebServiceHost(typeof(WCFTestServer), baseAddress);
        host.Open();
    }
    void StartClient()
    {
        try
        {
            WebClient wc = new WebClient();
            //GET
            string response1 = wc.DownloadString("http://localhost:8080/test/PutMessageGET/abcdef");
            //returns: "fedcba"
            //POST with UriTemplate
            string response2 = wc.UploadString("http://localhost:8080/test/PutMessagePOSTUriTemplate/abcdef",
                                                JsonConvert.SerializeObject(new { str = "12345" }));
            //returns: fedcba NOT 54321
            //POST with BodyStyle=WebMessageBodyStyle.WrappedRequest
            //Request: {"str":"12345"}
            wc.Headers["Content-Type"] = "application/json";
            string response3 = wc.UploadString("http://localhost:8080/test/PutMessagePOSTWrappedRequest",
                                                JsonConvert.SerializeObject(new { str="12345" }));
            //POST with BodyStyle=WebMessageBodyStyle.Bare
            wc.Headers["Content-Type"] = "application/json";
            string response4 = wc.UploadString("http://localhost:8080/test/PutMessagePOSTBare", "12345" );
                
        }
        catch (WebException wex)
        {
            Console.WriteLine(wex.Message);
        }
    }
