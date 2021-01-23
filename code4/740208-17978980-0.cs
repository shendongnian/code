    public class Material
    {
        [XmlIgnore]
        public string MaterialText { get; set; } 
        [XmlElement(ElementName = "mattext")]
        public XmlElement MatText
        {
            get {
                var doc = new XmlDocument();
                doc.LoadXml(MaterialText);
                return doc.DocumentElement;
            }
            set { /* implement in a similar way */ }
       }
