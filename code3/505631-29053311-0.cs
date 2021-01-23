    public class Product
    {
        [XmlAttribute( "id" )]
        public int Id
        {
            get;
            set;
        }
        [XmlAttribute( "name" )]
        public string Name
        {
            get;
            set;
        }
        [XmlAttribute( "quantity" )]
        public int Quantity
        {
            get;
            set;
        }
    }
    [XmlRoot( "Products" )]
    public class Products
    {
        [XmlAttribute( "nid" )]
        public int Id
        {
            get;
            set;
        }
        [XmlElement(ElementName = "Product")]
        public List<Product> AllProducts { get; set; }
    }
