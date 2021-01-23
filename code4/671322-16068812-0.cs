    [ServiceContract]
    public class MyServer
    {
        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                WebServiceHost ws = new WebServiceHost(this.GetType(), new Uri("http://0.0.0.0/Test"));
                ws.Open();
            });
        }
        [OperationContract]
        [WebInvoke(UriTemplate = "SaveUsersCode", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SaveUsers(UserCode code)
        {
            return "GOT: " + code.companyName + "," + code.imsi;
        }
        public class UserCode
        {
            public string companyName;
            public string imsi;
        }
    }
