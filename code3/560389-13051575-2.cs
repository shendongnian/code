	public ActionResult Save(string jsonData)
	{
		List<Product> selectedProducts = new JavaScriptSerializer().Deserialize<List<Product>>(jsonData);
		decimal totalPrice = selectedProducts.Sum(x => x.Price);
		ViewBag.SaleTotal = totalPrice;
		return RedirectToAction("Index");
	}
