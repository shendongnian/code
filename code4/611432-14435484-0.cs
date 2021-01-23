    void StartServer()
    {
        Task.Factory.StartNew(() =>
        {
            WebServiceHost host = new WebServiceHost(typeof(MyService), new Uri("http://0.0.0.0:80/MyService/"));
            host.Open();
        });
    }
    [ServiceContract]
    public class MyService
    {
        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public byte[] PostPackets(byte[] rawPackets)
        {
            rawPackets[0] = 99;
            return rawPackets;
        }
    }
