    public String GetEntityXml<T>(List<T> entities)
    {
        var xmlDoc = new XmlDocument();
        var nav = xmlDoc.CreateNavigator();
        using (var sw = new StringWriter())
        {
            //Create an XmlWriter that will omit xml declarations
            var s = new XmlWriterSettings{ OmitXmlDeclaration = true };
            using (var xmlWriter = XmlWriter.Create(sw, s))
            {
                //Use the following to serialize without namespaces
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var ser = new XmlSerializer(typeof(List<T>),
                              new XmlRootAttribute(typeof(T).Name + "_LIST"));
                ser.Serialize(xmlWriter, entities, ns);
            }
                    
            //Pass xml string to nav.AppendChild()
            nav.AppendChild(sw.ToString());
        }
    
        using (var stringWriter = new StringWriter())
        {
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
            }
            return stringWriter.ToString();
        }
    }
