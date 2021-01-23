     public class SoapHeaderBehaviour : BehaviorExtensionElement, IClientMessageInspector, IEndpointBehavior
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                try
                {
                    // Get the request into an XDocument
                    var memoryStream = new MemoryStream();
    
                    var writer = XmlDictionaryWriter.CreateTextWriter(memoryStream);
                    request.WriteMessage(writer);
                    writer.Flush();
                    memoryStream.Position = 0;
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(memoryStream);
    
                    // get the body tag
                    XmlNode bodyNode = FindNode("body", xmlDoc);
                    Debug.Assert(bodyNode != null, "Unable to find the BODY in the SOAP message");
                    if (bodyNode != null)
                    {
                        string MAC = GenerateMAC(bodyNode.InnerXml);
    
                        // replace the relevant item in the header
                        XmlNode tokenNode = FindNode("binarysecuritytoken", xmlDoc);
                        Debug.Assert(tokenNode != null, "Unable to find the BinarySecurityToken in the SOAP message");
    
                        if (tokenNode != null)
                        {
                            tokenNode.Attributes["Value"].Value = MAC;
    
                            // recreate the request
                            memoryStream = new MemoryStream();
                            writer = XmlDictionaryWriter.CreateTextWriter(memoryStream);
                            xmlDoc.WriteTo(writer);
                            writer.Flush();
                            memoryStream.Position = 0;
                            var reader = XmlDictionaryReader.CreateTextReader(memoryStream, XmlDictionaryReaderQuotas.Max);
                            var newRequest = Message.CreateMessage(reader, int.MaxValue, request.Version);
                            request = newRequest;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
    
                return null;
            }
    
            private XmlNode FindNode(string name, XmlDocument xmlDoc)
            {
                XmlNode node = null;
                for (int i = 0; i < xmlDoc.ChildNodes.Count; i++)
                {
                    node = FindNode(name, xmlDoc.ChildNodes[i]);
                    if (node != null)
                        break;
                }
    
                return node;
            }
    
            private XmlNode FindNode(string name, XmlNode parentNode)
            {
                if (parentNode != null && parentNode.Name.ToLower().Contains(name))
                {
                    return parentNode;
                }
    
                XmlNode childNode = null;
                for (int i = 0; i < parentNode.ChildNodes.Count; i++)
                {
                    childNode = FindNode(name, parentNode.ChildNodes[i]);
                    if (childNode != null)
                        break;
                }
    
                return childNode;
            }
    
            private string GenerateMAC(string soapXML)
            {
                // get the key from the web.config file
                var key = ConfigurationManager.AppSettings["Key"];
    
                ASCIIEncoding encoding = new ASCIIEncoding();
    
                //Convert from Hex to Bin
                byte[] keyBytes = StringToByteArray(key);
                //Convert String to Bytes
                byte[] xmlBytes = encoding.GetBytes(soapXML);
    
                //Perform the Mac goodies
                MACTripleDES desMac = new MACTripleDES(keyBytes);
                byte[] macBytes = desMac.ComputeHash(xmlBytes);
    
                //Base64 the Mac
                string base64Mac = Convert.ToBase64String(macBytes);
                return base64Mac;
            }
    
            private static byte[] StringToByteArray(string hex)
            {
                if (hex.Length % 2 != 0)
                {
                    throw new ArgumentException();
                }
    
                byte[] hexBytes = new byte[hex.Length / 2];
                for (int index = 0; index < hexBytes.Length; index++)
                {
                    string bytevalue = hex.Substring(index * 2, 2);
                    hexBytes[index] = Convert.ToByte(bytevalue, 16);
                }
    
                return hexBytes;
            }
    
            protected override object CreateBehavior()
            {
                return new SoapHeaderBehaviour();
            }
    
            public override Type BehaviorType
            {
                get
                {
                    return GetType();
                }
            }
    
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
            {
                behavior.MessageInspectors.Add(this);
                // behavior.MessageInspectors.Add(new FaultMessageInspector());
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
            {
            }
    
            public void Validate(ServiceEndpoint serviceEndpoint)
            {
            }
        }
