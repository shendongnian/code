	public static ShoppingCart GetInstance()
	{
		ShoppingCart cart = (ShoppingCart)Session["ASPNETShoppingCart"];
		
		if (cart == null)
		{
			Session["ASPNETShoppingCart"] = cart = new ShoppingCart();
		}
		
		return cart;
	}
	protected ShoppingCart()
	{
		Items = new List<CartItem>();
	}
