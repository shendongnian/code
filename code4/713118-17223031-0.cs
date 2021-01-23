	public ActionResult Add(int productId)
	{
		var products = Session["ShoppingList"] as List<int> ?? new List<int>();
		products.Add(productId);
		Session["ShoppingList"] = products;
		return View("Index");
	}
