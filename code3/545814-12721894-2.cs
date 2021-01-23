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
    	[XmlArrayItem(ElementName = "Category", Type = typeof(Category))]
    	public List<Category> Categories;
    }
    
    public class Category
    {
    	[XmlAttribute("Name")]
    	public string name;
    
    	[XmlElement("Description")]
    	public string description;
    }
