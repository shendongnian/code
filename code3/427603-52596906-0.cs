    using System.Data.Entity.Migrations;
    
    public void SaveProduct(Product product)
        {
            context.Set<Product>().AddOrUpdate(product);
    
            context.SaveChanges();
        }
