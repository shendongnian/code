    public class MyBehavior :  IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MyMessageInspector());
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class MyMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reply.ToString());
    
            List<XmlElement> items = new List<XmlElement>();
            Dictionary<string, XmlElement> multiRefs = new Dictionary<string,XmlElement>();
    
            InspectNodes(doc.DocumentElement, items, multiRefs);
    
            FixNodes(items, multiRefs);
    
            MemoryStream ms = new MemoryStream();
    
            XmlWriter writer = XmlWriter.Create(ms);
            doc.WriteTo(writer);
            writer.Flush();
            ms.Position = 0;
    
            XmlReader reader = XmlReader.Create(ms);
            reply = Message.CreateMessage(reader, int.MaxValue, reply.Version);
        }
    
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    
        private static void InspectNodes(XmlElement element, List<XmlElement> items, Dictionary<string, XmlElement> multiRefs)
        {
            string val = element.GetAttribute("href");
            if (val != null && val.StartsWith("#id"))
                items.Add(element);
            else if (element.Name == "multiRef")
                multiRefs[element.GetAttribute("id")] = element;
    
            foreach (XmlNode node in element.ChildNodes)
            {
                XmlElement child = node as XmlElement;
                if (child != null)
                    InspectNodes(child, items, multiRefs);
            }
    
        }
    
    
        private static void FixNodes(List<XmlElement> items, Dictionary<string, XmlElement> multiRefs)
        {
            // Reverse order so populate the id refs into one single element. This is only a solution in relation to the WSDL definition.
            for (int x = items.Count - 1; x >= 0; x--)
            {
                XmlElement element = items[x];
    
                string href = element.GetAttribute("href");
                if (String.IsNullOrEmpty(href))
                    continue;
    
                if (href.StartsWith("#"))
                    href = href.Remove(0, 1);
    
                XmlElement multiRef = multiRefs[href];
    
                if (multiRef == null)
                    continue;
    
                element.RemoveAttribute("href");
                element.InnerXml = multiRef.InnerXml;
    
                multiRef.ParentNode.RemoveChild(multiRef as XmlNode);
            }
        }
    
    }
