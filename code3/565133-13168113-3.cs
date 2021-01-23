    public void TestWCFService()
    {
        //Start Server
        Task.Factory.StartNew(
            (_) =>
            {
                Uri baseAddress = new Uri("http://localhost:8080/Test");
                WebServiceHost host = new WebServiceHost(typeof(TestService), 
                                                         baseAddress);
                host.Open();
            }, null, TaskCreationOptions.LongRunning).Wait();
        //Client
        string xml = @"<Login>
                          <username>test</username>
                          <password>foo</password>
                      </Login>";
        var wc = new WebClient();
        wc.Headers.Add("Content-Type", "application/xml; charset=utf-8");
        var result = wc.UploadString("http://localhost:8080/Test/Login", xml);
    }
    [ServiceContract(Namespace = "")]
    public class TestService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Xml, 
                   ResponseFormat = WebMessageFormat.Xml, 
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        public string Login(string username, string password)
        {
            return username + " " + password;
        }
    }
