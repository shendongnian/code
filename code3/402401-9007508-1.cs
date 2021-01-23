    [EnableClientAccess]
    public class MyDomainService
    {
        [Invoke]
        public List<Product> GetProductList()
        {
            var list = new List<Product>();
            ...
            return list;
        }
    }
