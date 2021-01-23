	public class ProductsWithDetailModel
	{
		public IEnumerable<Product> Products { get; set; }	// to loop over and display all products
		public Product DetailProduct { get; set; }			// to display product details, if not null
	}
