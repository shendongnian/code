    public class ProductViewModel
        {
            public ProductViewModel(List<Product> products, List<Category> categories)
            {
                this.Products = products;
                this.Categories = categories;
            }
     
            public List<Product> Products { get; set; }
            public List<Category> Categories { get; set; }
     
        }
 
