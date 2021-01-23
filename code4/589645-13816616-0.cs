    var result = 
        from a in
            (
                from p in TheProducts
                join o in ThePurchases
                on p.ProductID equals o.ProductID
                group p by new { p.ProductID, p.Name, p.Price } into g
                select new
                {
                    ProductID = g.Key.ProductID,
                    Name = g.Key.Name,
                    Total = g.Sum(i => i.Price)
                }
            )
        join b in
            (
                from p in TheProducts
                join o in ThePurchases
                on p.ProductID equals o.ProductID
                select new
                {
                    ProductID = p.ProductID,
                    Price = p.Price
                }
            )
        on a.ProductID equals b.ProductID
        where a.Total > b.Price
        select a.Name;
    result = result.Distinct();
