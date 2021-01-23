    static void Main(string[] args)
    {
        var sb = new StringWriter();
        using (var xml = XmlWriter.Create(sb, new XmlWriterSettings() { Indent = true }))
        {
            xml.WriteStartElement("root");
            using (var inner = XmlWriter.Create(xml))
            {
                Debug.WriteLine(Object.ReferenceEquals(xml, inner));
                //UH OH! Returns true
                inner.WriteStartElement("payload1");
                // simulate ThirdPartyLibrary.Serialise(results, inner) leaving a tag open
                inner.WriteStartElement("third-party-stuff");
            }
            xml.WriteStartElement("payload2");
        }
        sb.ToString().Dump();
    }
