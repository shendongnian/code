    public static List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        using (var entity = new SUIMSEntities1())
        {
            entity.Include("Category");  //force eager loading of Category
            products = (from p in entity.Products
                        select p).ToList();
            return products;
        }            
    }
