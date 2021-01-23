    List<Product1> prods = new List<Product1>();
            prods.Add(new Product1() { ProductPrice = 1, ValidFrom = DateTime.Today });
            prods.Add(new Product1() { ProductPrice = 3, ValidFrom = DateTime.Today });
            prods.Add(new Product1() { ProductPrice = 2, ValidFrom = DateTime.Today.AddDays(-1) });
            prods.Add(new Product1() { ProductPrice = 5, ValidFrom = DateTime.Today.AddDays(-2) });
        // Put any logic you want in sumFunc. For any field you want like ProductPrice 
        Func<Product1, decimal> sumFunc = (p) => p.ProductPrice;
        var result = from c in prods
                     group c by c.ValidFrom into gd
                     let sum = gd.Sum(sumFunc)
                     select sum;
