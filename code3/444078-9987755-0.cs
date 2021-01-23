    public void Linq11() 
    { 
        List<Product> products = GetProductList(); 
      
        var productInfos = 
            from p in products 
            select new { p.ProductName, p.Category, Price = p.UnitPrice }; 
      
        Console.WriteLine("Product Info:"); 
        foreach (var productInfo in productInfos) 
        { 
            Console.WriteLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price); 
        } 
    }
