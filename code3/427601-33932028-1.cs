    public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = context.Products.Create();
                product.property = ...;
                product.property = ...;
    
                context.Products.Add(product);
        }
    
        context.SaveChanges(); // Breakpoint here
    }
