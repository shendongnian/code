    private List<Product> GetProducts(string SupplierId, string ProductName)
    {
        //here you can pass SupplierId and ProductName as null when filtering 
        // is not required.
        var products = null;
         if(SupplierID != null)
         {
          products = from p in ctx.Products
                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               p.ProductDescription,
                               p.ListPrice
                           };
          }
         else
         {
             products = from p in ctx.Products
                           where p.SupplierID == SupplierID
                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               p.ProductDescription,
                               p.ListPrice
                           };
          }
    }
