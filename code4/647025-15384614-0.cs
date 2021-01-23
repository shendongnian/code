    internal class Program
        {
            private static void Main(string[] args)
            {
                //var products = new ProductCollection();
                //products.Add(new Product { ID = 1, Name = "Product1", Description = "This is product 1" });
                //products.Add(new Product { ID = 2, Name = "Product2", Description = "This is product 2" });
                //products.Add(new Product { ID = 3, Name = "Product3", Description = "This is product 3" });
                //products.Save("C:\\Test.xml");
    
                var products = ProductCollection.Load("C:\\Test.xml");
    
                Console.ReadLine();
            }
        }
    
        [XmlRoot("Products")]
        public class ProductCollection : List<Product>
        {
            public static ProductCollection Load(string fileName)
            {
                return new FileInfo(fileName).XmlDeserialize<ProductCollection>();
            }
    
            public void Save(string fileName)
            {
                this.XmlSerialize(fileName);
            }
        }
    
        public class Product
        {
            [XmlAttribute("ProductID")]
            public int ID { get; set; }
    
            public string Name { get; set; }
    
            public string Description { get; set; }
        }
