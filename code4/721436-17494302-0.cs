    // Notice no ToList(), since we want it as a subquery.
    var usedProductTypesIdSubquery =
        session.Query<Product>
               .Select(product => product.ProductType.Id);
    var usedProductTypes = 
        session.Query<ProductType>
               .Where(productType => usedProductTypesIdSubquery.Contains(productType.Id)
               .ToList();
    // Because we are using a subquery, and contains (the 'IN' clause in SQL), the
    // resulting list usedProductTypes will not contain duplicates.
       
