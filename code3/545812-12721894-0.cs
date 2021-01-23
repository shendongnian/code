    //...
    using System.Xml;
    using System.Xml.Serialization;
    //...
    [XmlRoot("Order")]
    public class Order
    {
        [XmlArrayItem(ElementName = "Product", Type = typeof(Product))]
        public List<Product> Products;
    }
    public class Product
    {
        public Category type;
    }
    
    public class Category
    {
        [XmlAttribute("Name")]
        public string name;
    
        [XmlElement("Description")]
        public string description;
    }
