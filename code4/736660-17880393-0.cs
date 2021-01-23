    [XmlType(TypeName = "CompanyXml")]
    public class Company : ISerializable
    {
        [XmlElement("Product")]
        public List<Product> ListProduct { get; set; }
        [XmlElement("CompanyName")]
        public string CompanyName { get; set; }
        [XmlElement("CompanyID")]
        public string CompanyID { get; set; }
    }
