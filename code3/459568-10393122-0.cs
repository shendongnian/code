    public class StackOverflow_10391354
    {
        [ServiceContract]
        public class Service
        {
            [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            public int Add(int x, int y)
            {
                return x + y;
            }
        }
        class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override WebHttpDispatchOperationSelector GetOperationSelector(ServiceEndpoint endpoint)
            {
                return new MyOperationSelector();
            }
            public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
            }
        }
        class MyOperationSelector : WebHttpDispatchOperationSelector
        {
            protected override string SelectOperation(ref Message message, out bool uriMatched)
            {
                HttpRequestMessageProperty prop = (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];
                if (message.Headers.To.LocalPath.EndsWith("/Add") && prop.Method == "GET")
                {
                    prop.Method = "POST";
                    uriMatched = true;
                    message = CreateBodyMessage(message);
                    return "Add";
                }
                else
                {
                    return base.SelectOperation(ref message, out uriMatched);
                }
            }
            private Message CreateBodyMessage(Message message)
            {
                HttpRequestMessageProperty prop = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                string queryString = prop.QueryString;
                NameValueCollection nvc = HttpUtility.ParseQueryString(queryString);
                StringBuilder sb = new StringBuilder();
                sb.Append('{');
                bool first = true;
                foreach (string key in nvc.Keys)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(',');
                    }
                    sb.Append('\"');
                    sb.Append(key);
                    sb.Append("\":\"");
                    sb.Append(nvc[key]);
                    sb.Append('\"');
                }
                sb.Append('}');
                string json = sb.ToString();
                XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(json), XmlDictionaryReaderQuotas.Max);
                Message result = Message.CreateMessage(MessageVersion.None, null, jsonReader);
                result.Properties.Add(HttpRequestMessageProperty.Name, prop);
                result.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Json));
                result.Headers.To = message.Headers.To;
                return result;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/Add?x=66&y=88"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
