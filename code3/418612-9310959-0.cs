    [XmlType("img")]
    [Serializable]
    public class ImageNameExceptionItemXml
    {
        [XmlAttribute("name")]
        public string Filename;
    }
    [XmlType("warn")]
    [Serializable]
    public class Warnning
    {
        [XmlArrayItem(typeof(ImageNameExceptionItemXml))]
        public List<ImageNameExceptionItemXml> imgs { get; set; }
    }
    [XmlRoot("configuration")]
    [Serializable]
    public class ImageNameExceptionListXml
    {
        [XmlArrayItem(typeof(Warnning))]
        public List<Warnning> warns{ get; set; }
        [XmlArrayItem(typeof(ImageNameExceptionItemXml))]
        public List<ImageNameExceptionItemXml> imgs { get; set; }
        
    }
