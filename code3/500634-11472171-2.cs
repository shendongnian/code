    some xml serializable class,
     {
        .......
    
        [XmlElement("PayLoad", Type=typeof(CDATA))]
        public CDATA PayLoad
        {
           get { return _payLoad; }
           set { _payLoad = value; }
        }
     }
    
    
     public class CDATA : IXmlSerializable
     {
        private string text;
        public CDATA()
        {}
    
        public CDATA(string text)
        {
           this.text = text;
        }
    
        public string Text
        {
           get { return text; }
        }
    
        /// <summary>
        /// Interface implementation not used here.
        /// </summary>
        XmlSchema IXmlSerializable.GetSchema()
        {
           return null;
        }
    
        /// <summary>
        /// Interface implementation, which reads the content of the CDATA tag
        /// </summary>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
           this.text = reader.ReadElementString();
        }
    
        /// <summary>
        /// Interface implementation, which writes the CDATA tag to the xml
        /// </summary>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
           writer.WriteCData(this.text);
        }
     }
