    public class MyDbAccessClass
    {
        public static List<Products> GetProducts()
        {
             var products = from o in RequestContext.Current.Products
                            select o;
             return products.ToList();
        }
    }
