    [XmlType("img")]
    public class ImageNameExceptionItemXml 
    { 
        [XmlAttribute("name")]     
        public string Filename; 
    }
    [XmlType("warn")]
    public class WarnExceptionItemXml
    {
        [XmlElement("img")]
        public List<ImageNameExceptionItemXml> ImgList { get; set; }
    }
    [XmlRoot("configuration")]
    public class ImageNameExceptionListXml
    {
        [XmlElement("img")]
        public List<ImageNameExceptionItemXml> ImgList { get; set; }
        [XmlElement("warn")]
        public WarnExceptionItemXml WarnList { get; set; } 
    }
