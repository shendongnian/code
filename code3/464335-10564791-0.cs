    public class StackOverflow_10519075
    {
        [DataContract(Name = "Person", Namespace = "")]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
        }
        [ServiceContract]
        public interface ITest
        {
            [WebGet]
            Person GetPerson();
        }
        public class Service : ITest
        {
            public Person GetPerson()
            {
                return new Person { Name = "John Doe", Age = 33 };
            }
        }
        public class MyHtmlAwareFormatter : IDispatchMessageFormatter
        {
            IDispatchMessageFormatter original;
            public MyHtmlAwareFormatter(IDispatchMessageFormatter original)
            {
                this.original = original;
            }
            public void DeserializeRequest(Message message, object[] parameters)
            {
                this.original.DeserializeRequest(message, parameters);
            }
            public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
            {
                MyUseHtmlExtension useHtml = OperationContext.Current.Extensions.Find<MyUseHtmlExtension>();
                if (useHtml != null && useHtml.UseHtmlResponse)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<html><head><title>Result of " + useHtml.OperationName + "</title></head>");
                    sb.AppendLine("<body><h1>Result of " + useHtml.OperationName + "</h1>");
                    sb.AppendLine("<p><b>" + result.GetType().FullName + "</b></p>");
                    sb.AppendLine("<ul>");
                    foreach (var prop in result.GetType().GetProperties())
                    {
                        string line = string.Format("{0}: {1}", prop.Name, prop.GetValue(result, null));
                        sb.AppendLine("<li>" + line + "</li>");
                    }
                    sb.AppendLine("</ul></body></html>");
                    byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
                    Message reply = Message.CreateMessage(messageVersion, null, new RawBodyWriter(bytes));
                    reply.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
                    HttpResponseMessageProperty httpResp = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name, httpResp);
                    httpResp.Headers[HttpResponseHeader.ContentType] = "text/html";
                    return reply;
                }
                else
                {
                    return original.SerializeReply(messageVersion, parameters, result);
                }
            }
            class RawBodyWriter : BodyWriter
            {
                private byte[] bytes;
                public RawBodyWriter(byte[] bytes)
                    : base(true)
                {
                    this.bytes = bytes;
                }
                protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
                {
                    writer.WriteStartElement("Binary");
                    writer.WriteBase64(this.bytes, 0, this.bytes.Length);
                    writer.WriteEndElement();
                }
            }
        }
        public class MyHtmlAwareInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                HttpRequestMessageProperty httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
                string accept = httpRequest.Headers[HttpRequestHeader.Accept];
                string operationName = request.Properties[WebHttpDispatchOperationSelector.HttpOperationNamePropertyName] as string;
                if (accept == "text/html")
                {
                    OperationContext.Current.Extensions.Add(new MyUseHtmlExtension { UseHtmlResponse = true, OperationName = operationName });
                }
                return null;
            }
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
            }
        }
        class MyUseHtmlExtension : IExtension<OperationContext>
        {
            public void Attach(OperationContext owner) { }
            public void Detach(OperationContext owner) { }
            public bool UseHtmlResponse { get; set; }
            public string OperationName { get; set; }
        }
        public class MyHtmlAwareEndpointBehavior : IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MyHtmlAwareInspector());
                foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
                {
                    operation.Formatter = new MyHtmlAwareFormatter(operation.Formatter);
                }
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new WebHttpBehavior { AutomaticFormatSelectionEnabled = true });
            endpoint.Behaviors.Add(new MyHtmlAwareEndpointBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c;
            c = new WebClient();
            c.Headers[HttpRequestHeader.Accept] = "application/json";
            Console.WriteLine(c.DownloadString(baseAddress + "/GetPerson"));
            Console.WriteLine();
            c = new WebClient();
            c.Headers[HttpRequestHeader.Accept] = "text/xml";
            Console.WriteLine(c.DownloadString(baseAddress + "/GetPerson"));
            Console.WriteLine();
            c = new WebClient();
            c.Headers[HttpRequestHeader.Accept] = "text/html";
            Console.WriteLine(c.DownloadString(baseAddress + "/GetPerson"));
            Console.WriteLine();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
