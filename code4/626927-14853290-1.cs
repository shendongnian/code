    public Product GetProductById(int productId)
    {
        using (var db = new ProductContext())
        {
           var query = from pr in db.Products.Include("Picture")
                       where pr.Id == productId
                       select pr;
    
            return query.FirstOrDefault();
        }
    }
