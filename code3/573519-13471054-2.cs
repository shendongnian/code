    public class XmlTextWriterFull2 : XmlWrappingWriter
    {
        public XmlTextWriterFull2(XmlWriter baseWriter)
            : base(baseWriter)
        {
        }
        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
