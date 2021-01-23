    public class MyXmlTextWriter : XmlTextWriter
    {
        public MyXmlTextWriter(Stream stream) : base(stream, Encoding.UTF8)
        {
        }
        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
