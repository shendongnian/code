    var x = from p in context.Products
            join o in OrderLines in p.Id = o.ItemId
            select new    // you are creating your anonymous type here
            {
                OrderId = o.Id,
                ProductName = p.Name,
                OrderDate = o.Date
            }
    foreach (var y in x)
    {
        Console.WriteLine("Product name: " + y.ProductName);
    }
