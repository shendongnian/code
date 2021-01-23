            // Building of my XML 
            XNamespace env = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace xsd = "http://www.w3.org/2001/XMLSchema";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace enc = "http://schemas.xmlsoap.org/soap/encoding/";
            XNamespace typens = "urn:...";
            XNamespace xsiType = "xsd:string";
            XElement soapEnv = new XElement(env + "Envelope",
                new XAttribute(XNamespace.Xmlns + "SOAP-ENV",env.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "xsd", xsd.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                new XElement(env + "Body",
                    new XAttribute(env + "encodingStyle",enc.NamespaceName),
                        new XElement(typens + "MethodName",
                            new XAttribute(XNamespace.Xmlns + "typens",typens.NamespaceName),
                            new XElement("elementName",
                                new XAttribute(xsi + "type",xsiType.NamespaceName), "...value"),
                            new XElement("elementName",
                                new XAttribute(xsi + "type",xsiType.NamespaceName),"...value"),
                            new XElement("elementName",
                                new XAttribute(xsi + "type",xsiType.NamespaceName),"...value")
            )));
            // HTTPWEBREQUEST
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("...url...");
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            webRequest.Method = "POST";
            webRequest.KeepAlive = false;
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.CookieContainer = new CookieContainer();
            webRequest.Headers.Add("SOAPAction", "...webservice link...");
            webRequest.ProtocolVersion = new Version(1,1);
            webRequest.Timeout = 1000;
            
            
            using (StreamWriter stream = new StreamWriter(webRequest.GetRequestStream()))
            { 
                stream.Write(soapEnv); 
                stream.Flush();
                stream.Close();            
            }
            
            
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    if (responseReader != null)
                    {
                        .....code....
                        webResponse.Close();
                    }
                }            
            }
