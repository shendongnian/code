    class Program
    {
        static void Main(string[] args)
        {
            HttpConfiguration config = new HttpConfiguration();
            DataContractSerializer productsSerializer = new DataContractSerializer(typeof(List<Product>), "Products", String.Empty);
            config.Formatters.XmlFormatter.SetSerializer(typeof(List<Product>), productsSerializer);
            config.Formatters.XmlFormatter.Indent = true;
            config.Formatters.XmlFormatter.WriteToStreamAsync(
                typeof(List<Product>),
                new List<Product> { new Product { Name = "Product1" }, new Product { Name = "Product2" } },
                Console.OpenStandardOutput(),
                null,
                null).Wait();
            Console.WriteLine();
        }
    }
    [DataContract(Namespace = "")]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }
    }
