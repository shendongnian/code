    from c in northwind.Customers
    from o in c.Orders  //all froms except first are calls to SelectMany (one to many)
    from od in o.OrderDetails //navigational properties -> no need to write explicit joins
    let p = od.Product  // now we go many to one, so we don't need SelectMany
    group od
      by new {c.Country, Product = p }   //anon grouping key
      into productGroup
    let country = productGroup.Key.Country
    let product = productGroup.Key.Product
    let quantity = productGroup.Sum(od2 => od2.Quantity)
    group new {Product = product, Quantity = quantity} //anon group elements
      by country
      into countryGroups
    select new {
      Country = countryGroups.Key,
      Summaries = countryGroups
        .OrderByDescending(summary => summary.Quantity)
        .ThenBy(summary => summary.Product.ProductId) //tiebreaker
        .Take(5)
        .ToList()
    }
