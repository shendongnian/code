    public class Product 
    { 
	    public int Id { get; set; } 
	    public string Name { get; set; } 
	    public decimal Price { get; set; }
	    public int? SellerId { get; set; }
	    public Seller Seller { get; set; }
        public static Product GetProductById(int id)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection("connectionString"))
            {
                product = connection.Query<Product>("select * from Product where Id = @Id", new { Id = id }).Single();
                product.Seller = connection.Query<Seller>("select * from Seller where Id = @Id", new { Id = product.SellerId }).Single();
            }
            return product;
        }
    }
    public class Seller 
    { 
	    public int Id { get; set; } 
	    public string Name { get; set; } 
	    public List<Product> Products { get; set; } 
        public static Seller GetSellerById(int id)
        {
            Seller seller = null;
            using(SqlConnection connection = new SqlConnection("connectionString"))
            {
                seller = connection.Query<Seller>("select * from Seller where Id = @Id", new { Id = id }).Single();
                seller.Products = connection.Query<Product>("select * from Product where SellerId = @Id", new { Id = id }).ToList();
                seller.Products.ForEach(p => p.Seller = seller);
            }
            return seller;
        }
    }
