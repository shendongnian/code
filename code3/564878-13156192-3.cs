    int[] productList = new int[] { 1, 2, 3, 4 };
    List<Product> products = new List<Product>();
    products.Add(new Product { ID = 1, Name = "Test" });
    products.Add(new Product { ID = 2, Name = "Test" });
    products.Add(new Product { ID = 6, Name = "Test" });
    var myProducts = from p in products
                     where productList.Contains(p.ID)
                     select p;
    var methodChainingQuery = products.Where(c => productList.Contains(c.ID));
