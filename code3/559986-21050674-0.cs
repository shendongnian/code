        private MyResponseObject DeserializedResponse()
        {
            var rootAttribute = new XmlRootAttribute("MyResponseObject ");
            rootAttribute.Namespace = @"http://www.company.com/MyResponseObjectNamespace";
            XmlSerializer serializer = new XmlSerializer(typeof(MyResponseObject ), rootAttribute);
            string responseSoapBodyInnerXml = GetSoapBodyInnerXml(_requestInspector.Response);
            AddXmlDeclaration(ref responseSoapBodyInnerXml);
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(responseSoapBodyInnerXml));
            MyResponseObject resultingResponse = (MyResponseObject )serializer.Deserialize(memStream);
            return resultingResponse;
        }
        private string GetSoapBodyInnerXml(string soapMessage)
        {
            XDocument xDoc = XDocument.Parse(soapMessage);
            XNamespace nsSoap = @"http://schemas.xmlsoap.org/soap/envelope/";
            return xDoc.Descendants(nsSoap + CONST_SoapBody).Descendants().First().ToString();
        }
        private void AddXmlDeclaration(ref string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            //Create an XML declaration. 
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //Add the new node to the document.
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            //Return updated xmlString with XML Declaration
            xmlString = doc.InnerXml;
        }
