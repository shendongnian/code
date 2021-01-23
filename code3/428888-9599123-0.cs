    public void SaveProduct(Product product, string userID)
    {
        if (product.ProductID == 0)
        {
            context.Products.Add(product);
        }
        else
        {
            Product prodToUpdate = context.Products
              .Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            if (prodToUpdate != null)
            {
                context.Entry(prodToUpdate).CurrentValues.SetValues(product);
            }
        }
        context.SaveChanges(userID);
    }
