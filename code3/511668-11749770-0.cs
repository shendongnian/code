            const string ValueIsNull = "value is null";
            string returnResponse;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response == null)
                {
                    return ValueIsNull;
                }
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        return ValueIsNull;
                    }
                    using (var reader = new StreamReader(responseStream))
                    {
                        returnResponse = reader.ReadToEnd();
                    }
                }
            }
            var doc = new XmlDocument();
            doc.LoadXml(returnResponse);
            var namespaces = new XmlNamespaceManager(doc.NameTable);
            namespaces.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
            namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            namespaces.AddNamespace("ns1", "urn:oasis:names:tc:SPML:2:0:search");
            namespaces.AddNamespace("ns2", "urn:oasis:names:tc:SPML:2:0");
            namespaces.AddNamespace("ns3", "urn:oasis:names:tc:SPML:2:0");
            namespaces.AddNamespace("ns4", "urn:oasis:names:tc:DSML:2:0:core");
            XmlNode root = doc.DocumentElement;
            if (root == null)
            {
                return ValueIsNull;
            }
            var searchResponse = root.SelectSingleNode("/soapenv:Envelope/soapenv:Body/processRequestResponse/parameters/ns1:searchResponse", namespaces);
            if ((searchResponse == null) || (searchResponse.Attributes == null))
            {
                return ValueIsNull;
            }
            var status = (XmlAttribute)searchResponse.Attributes.GetNamedItem("status");
            return status == null ? ValueIsNull : status.Value;
