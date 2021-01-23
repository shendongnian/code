    public class ProductDetail
    {
        public int Id { get; }
    	public string Name { get; set; }
    	public double Price { get; set; }
    	public string Manufacturer { get; set; }
    	
    	private ProductDetail()
    	{
    	}
    	
    	public double ComputeValue()
    	{
    	}
    	
    	public static ProductDetail(ProductSummary summary)
    	{
    	    var newProduct = new ProductDetail();
    	    // load Product data using primary key from summary.Id		
    		// populate newProduct from loaded data
    		return newProduct;
    	}
    }
