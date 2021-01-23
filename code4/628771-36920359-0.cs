    public static ComplexData DesignTimeItem
    {
        get
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var products = from p in db.products.Include("ProductType")
                               where p.product_id == 131
                               select p;
 
                product product = products.First();
 
                return new ComplexData(product, "100 kg");
            }
        }
    }
