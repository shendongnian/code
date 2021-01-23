    public void TestWCFService()
    {
        //Start Server
        Task.Factory.StartNew(
            (_) =>{
                Uri baseAddress = new Uri("http://localhost:8080/Test");
                WebServiceHost host = new WebServiceHost(typeof(TestService), baseAddress);
                host.Open();
            },null,TaskCreationOptions.LongRunning).Wait();
        //Client
        var jsonString = new JavaScriptSerializer().Serialize(new { xaction = new { Imei = "121212", FileName = "Finger.NST" } });
        WebClient wc = new WebClient();
        wc.Headers.Add("Content-Type", "application/json");
        var result = wc.UploadString("http://localhost:8080/Test/Hello", jsonString);
    }
    [ServiceContract]
    public class TestService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public User Hello(Transaction xaction)
        {
            return new User() { Id = 1, Name = "Joe", Xaction = xaction };
        }
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Transaction Xaction { get; set; }
        }
        public class Transaction
        {
            public string Imei { get; set; }
            public string FileName { get; set; }
        }
    }
