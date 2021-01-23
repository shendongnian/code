	public ActionResult TestAction(int productId)
	{
		// TODO: error checking
		Products.Single(m => m.ProductId == productId).ViewDetail = true;
		return View(Products);
	}
