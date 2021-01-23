    using (AdventureWorksEntities context =
        new AdventureWorksEntities())
    {
        // Call the constructor with a query for products and the ObjectContext.
        ObjectQuery<Product> productQuery1 =
            new ObjectQuery<Product>("Products", context);
    
        foreach (Product result in productQuery1)
            Console.WriteLine("Product Name: {0}", result.Name);
    
        string queryString =
            @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product";
    
        // Call the constructor with the specified query and the ObjectContext.
        ObjectQuery<Product> productQuery2 =
            new ObjectQuery<Product>(queryString, context);
    
        foreach (Product result in productQuery2)
            Console.WriteLine("Product Name: {0}", result.Name);
    
        // Call the constructor with the specified query, the ObjectContext,  // and the NoTracking merge option.
        ObjectQuery<Product> productQuery3 =
            new ObjectQuery<Product>(queryString,
                context, MergeOption.NoTracking);
    
        foreach (Product result in productQuery3)
            Console.WriteLine("Product Name: {0}", result.Name);
    }
