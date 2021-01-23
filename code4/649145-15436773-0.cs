    public class StackOverflow_15434117
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
        }
        [ServiceContract]
        public interface IConditionalMetadata
        {
            [WebGet]
            XmlElement GetWSDL(string endpoint);
        }
        public class Service : ITest, IConditionalMetadata
        {
            public string Echo(string text)
            {
                return text;
            }
            public XmlElement GetWSDL(string endpoint)
            {
                WebClient c = new WebClient();
                string baseAddress = OperationContext.Current.Host.BaseAddresses[0].ToString();
                byte[] existingMetadata = c.DownloadData(baseAddress + "?wsdl");
                XmlDocument doc = new XmlDocument();
                doc.Load(new MemoryStream(existingMetadata));
                XmlElement result = doc.DocumentElement;
                XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                nsManager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
                nsManager.AddNamespace("soap11", "http://schemas.xmlsoap.org/wsdl/soap/");
                nsManager.AddNamespace("soap12", "http://schemas.xmlsoap.org/wsdl/soap12/");
                List<XmlNode> toRemove = new List<XmlNode>();
                // Remove all SOAP 1.1 endpoints which are not the requested one
                XmlNodeList toRemove11 = result.SelectNodes("//wsdl:service/wsdl:port/soap11:address", nsManager);
                XmlNodeList toRemove12 = result.SelectNodes("//wsdl:service/wsdl:port/soap12:address", nsManager);
                foreach (XmlNode node in toRemove11)
                {
                    if (!node.Attributes["location"].Value.EndsWith(endpoint, StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove.Add(node);
                    }
                }
                foreach (XmlNode node in toRemove12)
                {
                    if (!node.Attributes["location"].Value.EndsWith(endpoint, StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove.Add(node);
                    }
                }
                List<string> bindingsToRemove = new List<string>();
                foreach (XmlNode node in toRemove)
                {
                    string binding;
                    RemoveWsdlPort(node, out binding);
                    bindingsToRemove.Add(binding);
                }
                toRemove.Clear();
                foreach (var binding in bindingsToRemove)
                {
                    string[] parts = binding.Split(':');
                    foreach (XmlNode node in result.SelectNodes("//wsdl:binding[@name='" + parts[1] + "']", nsManager))
                    {
                        toRemove.Add(node);
                    }
                }
                foreach (XmlNode bindingNode in toRemove)
                {
                    bindingNode.ParentNode.RemoveChild(bindingNode);
                }
                return result;
            }
            static void RemoveWsdlPort(XmlNode wsdlPortDescendant, out string binding)
            {
                while (wsdlPortDescendant.LocalName != "port" && wsdlPortDescendant.NamespaceURI != "http://schemas.xmlsoap.org/wsdl/")
                {
                    wsdlPortDescendant = wsdlPortDescendant.ParentNode;
                }
                binding = wsdlPortDescendant.Attributes["binding"].Value;
                var removed = wsdlPortDescendant.ParentNode.RemoveChild(wsdlPortDescendant);
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "basic");
            host.AddServiceEndpoint(typeof(ITest), new WSHttpBinding(), "ws");
            host.AddServiceEndpoint(typeof(IConditionalMetadata), new WebHttpBinding(), "conditionalWsdl")
                .Behaviors.Add(new WebHttpBehavior());
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress + "/basic"));
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Echo("Hello"));
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.WriteLine("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
