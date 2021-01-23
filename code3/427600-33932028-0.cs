    public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = context.Products.Create();
                product.propertiy = ...;
                product.propertiy = ...;
    
                context.Products.Add(product);
        }
    
        context.SaveChanges(); // Breakpoint here
    }
