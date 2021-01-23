    class Product
    {
    	static readonly IDictionary<ProductType, string[]> productType_Identifiers = 
    		new Dictionary<ProductType, string[]>
    		{
    			{ProductType.Food, new[]{ "chocolate", "chocolates" }},
    			{ProductType.Medical, new[]{ "pills" }},
    			{ProductType.Book, new[]{ "book" }}
    		};
    
    	public decimal ShelfPrice { get; set; }
    
    	public string Name { get; set; }
    
    	public bool IsImported { get { return Name.Contains("imported "); } }
    
    	public bool IsOf(ProductType productType)
    	{
    		return productType_Identifiers.ContainsKey(productType) &&
    			productType_Identifiers[productType].Any(x => Name.Contains(x));
    	}
    }
    class ShoppringCart
    {
        public IList<ShoppringCartItem> CartItems { get; set; }
    
        public decimal TotalTax { get { return CartItems.Sum(x => x.Tax); } }
    
        public decimal TotalCost { get { return CartItems.Sum(x => x.Cost); } }
    }
    
    class ShoppringCartItem
    {
        public Product Product { get; set; }
    
        public int Quantity { get; set; }
    
        public decimal Tax { get; set; }
    
        public decimal Cost { get { return Quantity * (Tax + Product.ShelfPrice); } }
    }
