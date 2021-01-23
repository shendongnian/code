    XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { OmitXmlDeclaration = true });
    var ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    XmlSerializer xml = new XmlSerializer(typeof(DecimalField));
            
    xml.Serialize(writer, obj, ns);
-
    [XmlRoot("Val")]
    public class DecimalField
    {
        [XmlText]
        public decimal Value { get; set; }
        [XmlAttribute]
        public bool Estimate { get; set; }
    }
