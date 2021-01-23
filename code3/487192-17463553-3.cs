    string serialXML = string.Empty;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
    
            XmlSerializer serializer = new XmlSerializer(p.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (XmlWriter writer = new RDECommon.Xml.NoNamespaceXmlWriter(sw))
            {
                serializer.Serialize(writer, p, ns);
                serialXML = sb.ToString();
            }
