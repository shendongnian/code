    class DataBaseContext
    {
         //...
         public IQueryable<Product> Products
         {
             get
             {
                 return this.Set<Product>().Where(pr => pr.IsActive == true);
             }
         }
    }
