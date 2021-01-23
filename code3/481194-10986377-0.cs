    public class StackOverflow_10970052
    {
        [ServiceContract]
        public class Service
        {
            [OperationContract]
            public int Add(int x, int y)
            {
                return x + y;
            }
            [OperationContract]
            public int Subtract(int x, int y)
            {
                return x + y;
            }
            [OperationContract, WebInvoke]
            public string Echo(string input)
            {
                return input;
            }
        }
        public class MyGetDefaultWebHttpBehavior : WebHttpBehavior
        {
            public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    if (operation.Behaviors.Find<WebGetAttribute>() == null && operation.Behaviors.Find<WebInvokeAttribute>() == null)
                    {
                        operation.Behaviors.Add(new WebGetAttribute());
                    }
                }
                base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), "").Behaviors.Add(new MyGetDefaultWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/Add?x=6&y=8"));
            c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/Subtract?x=6&y=8"));
            c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            Console.WriteLine(c.UploadString(baseAddress + "/Echo", "\"hello world\""));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
