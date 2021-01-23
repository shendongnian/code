    [XmlRoot(ElementName = "embellishments", IsNullable = false)]
    public class EmbellishmentGroup
    {
        [XmlElement("type")]
        public MyType Type { get; set; }
        public EmbellishmentGroup() 
        {
            Type = new MyType();
        }
    }
    public class MyType
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("row")]
        public List<Product> List { get; set; }
        public MyType()
        {
            Id = 1;
            Name = "bar bar foo";
            List = new List<Product>();
            Product p = new Product();
            p.Id = 1;
            p.Name = "foo bar";
            p.Cost = 10m;
            List.Add(p);
        }
    }
    public class Product
    {
        [XmlElement( "id" )]
        public int Id { get; set; }
    
        [XmlElement( "name" )]
        public string Name { get; set; }
    
        [XmlElement( "cost" )]
        public decimal Cost { get; set; }
    }
