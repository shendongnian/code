    class Program
        {
            static void Main(string[] args)
            {
                using (FileStream fs = new FileStream("xml.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Products));
    
                    var products = serializer.Deserialize(fs) as Products;
                }
            }
        }
        [XmlType("products")]
        [XmlInclude(typeof(Products))]
        public class Products
        {
            [XmlElement("product")]
            public List<Product> Items { get; set; }
        }
        [XmlType("product")]
        [XmlInclude(typeof(Product))]
        public class Product
        {
            [XmlElement("name")]
            String Name { get; set; }
    
            [XmlElement("description")]
            String Description { get; set; }
    
            [XmlElement("company")]
            Company Brand { get; set; }
    
            [XmlElement("grossprice")]
            String GrossPrice { get; set; }
    
            [XmlElement("netprice")]
            String NetPrice { get; set; }
    
            [XmlElement("measure")]
            String Measure { get; set; }
    
            [XmlElement("categoy")]
            ProductCategory Category { get; set; }
        }
        [XmlType("company")]
        [XmlInclude(typeof(Company))]
        public class Company
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("description")]
            public string Description { get; set; }
            [XmlElement("year")]
            public string Year { get; set; }
            [XmlElement("address")]
            public Address Address { get; set; }
    
            public Company()
            {
    
            }
        }
        [XmlType("address")]
        [XmlInclude(typeof(Address))]
        public class Address
        {
            [XmlElement("houseno")]
            public string HouseNumber { get; set; }
            [XmlElement("street")]
            public string Street { get; set; }
            [XmlElement("city")]
            public string City { get; set; }
            [XmlElement("country")]
            public string Country { get; set; }
            [XmlElement("pin")]
            public string Pin { get; set; }
    
            public Address()
            {
    
            }
        }
        [XmlType("category")]
        [XmlInclude(typeof(ProductCategory))]
        public class ProductCategory
        {
            public ProductCategory()
            {
    
            }
        }
