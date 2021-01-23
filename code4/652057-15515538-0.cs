    public class  Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
    public class ShoppingCart
    {
        public string CartId { get; set; }
        public List<Product> Products { get; set; }
        public void AddProductToCart(Product p)
        {
            if(Products==null)
                Products = new List<Product>();
             if(p!=null)
                     Products.Add(p);
        }
        public double CartPrice()
        {
            return Products != null ? Products.Sum(p => p.Price):0D;
        }
    }
