    public class StackOverflow_11342272
    {
        [ServiceContract]
        public class Service
        {
            [OperationContract]
            [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            public Stream DoWork()
            {
                string json = "{\"name\":\"John Doe\",\"age\":33,\"married\":true}";
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                return ms;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/DoWork"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
