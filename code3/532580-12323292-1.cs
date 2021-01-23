            // declare an XmlAttributes object, indicating that the namespaces declaration should be kept
            var atts = new XmlAttributes { Xmlns = true };
            // declare an XmlAttributesOverrides object and ...
            var xover = new XmlAttributeOverrides();
            // ... add the XmlAttributes object with regard to the "Namespaces" property member of the "Message" type
            xover.Add(typeof(MyType), "Namespaces", atts);
            // set the Namespaces property for each message in the payload body
            var messageNamespaces = new XmlSerializerNamespaces();
            messageNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            foreach (var message in myInboundMessage._messages)
            {
                message.Namespaces = messageNamespaces;
            }
            // create a serializer
            var serializer = new XmlSerializer(object2Serialize.GetType(), xover);
            // add the namespaces for the root element
            var rootNamespaces = new XmlSerializerNamespaces();
            rootNamespaces.Add("", "http://www.myurl.net");
            // serialize and extract the XML as text
            string objectAsXmlText;
            using (var stream = new MemoryStream())
            using (var xmlTextWriter = new XmlTextWriter(stream, null))
            {
                serializer.Serialize(xmlTextWriter, object2Serialize, rootNamespaces);
                stream.Seek(0, SeekOrigin.Begin);
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                objectAsXmlText = Encoding.UTF8.GetString(buffer);
            }
