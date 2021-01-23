    [XmlType(TypeName = "Product")]
    public class Product : ISerializable
    {
        [XmlElement("ProductName")]
        public string ProductName { get; set; }
        [XmlElement("ProductID")]
        public string ProductID { get; set; }
        [XmlElement("Expires")]
        public string Expires { get; set; }
    }
