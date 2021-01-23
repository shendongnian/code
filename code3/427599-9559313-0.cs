    if (product.ProductID == 0)
    {
        context.Entry(product).State = EntityState.Added;
    }
    else
    {
        context.Entry(product).State = EntityState.Modified;
    }
    context.SaveChanges();
