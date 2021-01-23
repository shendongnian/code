    interface IProductRepository
    {
	IEnumerable<Product> GetAll();
    }
    public class Product
    {
        [Display(Name = "Product ID")]
        public int ID { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Category")]
        public string Category { get; set; }
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }
    }
    public class ProductRepository 
    {
        private List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products.Add(new Product { ID = 1, Name = "xyz", Category = "Cat A", Price = 1 });
            products.Add(new Product { ID = 2, Name = "xyz", Category = "Cat B", Price = 100 });
            products.Add(new Product { ID = 3, Name = "xyz", Category = "Cat C", Price = 1000 });
            products.Add(new Product { ID = 4, Name = "xyz", Category = "Cat D", Price = 10000 });
        }
        public IEnumerable<Product> GetAll()
        {
            return products;
        }        
    }
        public ActionResult Index(Product model)
        {   
            repository.GetAll();
            //put foreach() here...
            return View();
        }
