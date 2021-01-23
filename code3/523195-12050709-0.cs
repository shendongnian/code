    public void SaveProduct(Product product)
    {
        if (product.ProductID == 0)
            context.Products.Add(product);
        else
        {    
            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
        }
        context.SaveChanges();
    }
