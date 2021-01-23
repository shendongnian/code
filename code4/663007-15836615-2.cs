    static void Main(string[] args)
        {
            var sb = new StringWriter();
            var sb2 = new StringWriter();
            using (var xml = XmlWriter.Create(sb, new XmlWriterSettings() { Indent = true }))
            {
                xml.WriteStartElement("root");
                using (var inner = XmlWriter.Create(sb2, new XmlWriterSettings() {Indent = true , CloseOutput=true, OmitXmlDeclaration=true}))
                {
                    
                    inner.WriteStartElement("payload1");
                    inner.WriteStartElement("third-party-stuff");
                }
                xml.WriteRaw(sb2.ToString());
                xml.WriteStartElement("payload2");
            }
            Debug.WriteLine(sb.ToString());            
        }
