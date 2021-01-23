    [Serializable, System.Xml.Serialization.XmlRoot("myList")]
    public class myList
    {
    	[XmlElement]
        public List<myItem> myItem { get; set; }
    }
