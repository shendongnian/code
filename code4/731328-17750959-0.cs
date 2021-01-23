    public class Cart
    {
    	private List<ICartItem> CartItems;
    
    	// ...Other Class Methods...
    
    	[HttpPost]
    	public void AddItem(int productVariantID)
    	{
    		var product = ProductService.GetByVariantID(productVariantID);
    
    		if (product != null)
    		{
    			CartItems.Add(CartItemConverter.Convert(product));
    			CartService.AddItem(productVariantID);
    		}
    	}
    
    	[HttpPost]
    	public void RemoveItem(int productVariantID)
    	{
    		CartItems.RemoveAll(c => c.VariantID == productVariantID);
    		CartService.RemoveItem(productVariantID);
    	}
    
    	public IEnumerable<ICartItem> GetCartItems()
    	{
    	    return CartItems;
    	}
    
    	// ...Other Class Methods...
    }
