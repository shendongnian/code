            var myObj = new MyObject();
            // removes version
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlSerializer xsSubmit = new XmlSerializer(typeof(MyObject));
            StringWriter sww = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(sww, settings))
            {
                // removes namespace
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                xsSubmit.Serialize(writer, myObj, xmlns);
                return sww.ToString(); // Your XML
            }
