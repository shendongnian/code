    public class NoNamespaceXmlWriter : XmlTextWriter
    {
                public NoNamespaceXmlWriter(System.IO.TextWriter output)
                    : base(output)
                {
                    Formatting = System.Xml.Formatting.None;
                }
    
                public override void WriteStartDocument() { }
                public override void WriteStartElement(string prefix, string localName, string ns)
                {
                    base.WriteStartElement("", localName, "");
                }
            }
