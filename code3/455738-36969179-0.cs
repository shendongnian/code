        private static T DeserializeInnerSoapObject<T>(string soapResponse)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(soapResponse);
            var soapBody = xmlDocument.GetElementsByTagName("soap:Body")[0];
            string innerObject = soapBody.InnerXml;
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(innerObject))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }
