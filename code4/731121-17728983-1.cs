    var results = productList
                     .GroupBy(p => p.ProductName)
                     .Select(g => new { ProductName = g.Key, Quantity = g.Sum() });
    foreach(var product in results)
    {
         Console.WriteLine("{0}      {1}", product.ProductName, product.Quantity);
    }
