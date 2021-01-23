    public class StackOverflow_10388746
    {
        [ServiceContract]
        public interface ICalculator
        {
            [WebGet]
            int Add(int x, int y);
            [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            int Subtract(int x, int y);
        }
        public class Service : ICalculator
        {
            public int Add(int x, int y)
            {
                PrintHeaders("Add");
                return x + y;
            }
            public int Subtract(int x, int y)
            {
                PrintHeaders("Subtract");
                return x - y;
            }
            void PrintHeaders(string operation)
            {
                Console.WriteLine("Incoming HTTP headers for operation '{0}'", operation);
                foreach (var header in WebOperationContext.Current.IncomingRequest.Headers.AllKeys)
                {
                    Console.WriteLine("  {0}: {1}", header, WebOperationContext.Current.IncomingRequest.Headers[header]);
                }
            }
        }
        public class MyWebClient : ClientBase<ICalculator>, ICalculator
        {
            Dictionary<string, string> outgoingHeaders = new Dictionary<string, string>();
            public MyWebClient(Uri baseAddress)
                : base(new WebHttpBinding(), new EndpointAddress(baseAddress))
            {
                this.Endpoint.Behaviors.Add(new WebHttpBehavior());
            }
            #region ICalculator Members
            public int Add(int x, int y)
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                    foreach (var headerName in this.outgoingHeaders.Keys)
                    {
                        WebOperationContext.Current.OutgoingRequest.Headers.Add(headerName, this.outgoingHeaders[headerName]);
                    }
                    this.outgoingHeaders.Clear();
                    return this.Channel.Add(x, y);
                }
            }
            public int Subtract(int x, int y)
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                    foreach (var headerName in this.outgoingHeaders.Keys)
                    {
                        WebOperationContext.Current.OutgoingRequest.Headers.Add(headerName, this.outgoingHeaders[headerName]);
                    }
                    this.outgoingHeaders.Clear();
                    return this.Channel.Subtract(x, y);
                }
            }
            #endregion
            public void AddOutgoingHeader(string name, string value)
            {
                this.outgoingHeaders.Add(name, value);
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebChannelFactory<ICalculator> factory = new WebChannelFactory<ICalculator>(new Uri(baseAddress));
            ICalculator proxy = factory.CreateChannel();
            using (new OperationContextScope((IContextChannel)proxy))
            {
                WebOperationContext.Current.OutgoingRequest.Headers.Add("referer", "http://stackoverflow.com");
                WebOperationContext.Current.OutgoingRequest.Headers.Add("user-agent", "Mozilla/5.0");
                Console.WriteLine("Add: {0}", proxy.Add(33, 55));
                Console.WriteLine();
            }
            using (new OperationContextScope((IContextChannel)proxy))
            {
                WebOperationContext.Current.OutgoingRequest.Headers.Add("referer", "http://stackoverflow.com");
                WebOperationContext.Current.OutgoingRequest.Headers.Add("user-agent", "Mozilla/5.0");
                Console.WriteLine("Subtract: {0}", proxy.Subtract(44, 33));
                Console.WriteLine();
            }
            MyWebClient client = new MyWebClient(new Uri(baseAddress));
            client.AddOutgoingHeader("referer", "http://stackoverflow.com");
            client.AddOutgoingHeader("user-agent", "Mozilla/5.0");
            Console.WriteLine("Add (via client): {0}", client.Add(44, 77));
            Console.WriteLine();
            client.AddOutgoingHeader("referer", "http://stackoverflow.com/another");
            client.AddOutgoingHeader("user-agent", "Mozilla/5.0-b");
            Console.WriteLine("Add (via client): {0}", client.Subtract(44, 77));
            Console.WriteLine();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
