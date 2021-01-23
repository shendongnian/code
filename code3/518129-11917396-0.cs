    var products = new List<Product>();
	
	products.Add(new Product { ID = 1, CategoryID = 1, ProductName = "1" });
	products.Add(new Product { ID = 2, CategoryID = 1, ProductName = "2" });
	products.Add(new Product { ID = 3, CategoryID = 7, ProductName = "3" });
	products.Add(new Product { ID = 4, CategoryID = 8, ProductName = "4" });
	products.Add(new Product { ID = 5, CategoryID = 9, ProductName = "5" });
	products.Add(new Product { ID = 6, CategoryID = 10, ProductName = "6" });
	
	products
		.OrderByDescending(p => p.CategoryID == 1 || p.CategoryID == 8 || p.CategoryID == 9)
		.ThenBy(p => p.CategoryID);
