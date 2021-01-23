    interface IRepository<T>
    {
        IQueryable<T> FindAll();
    }
    
    interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsInCategory(int categoryId);
        IEnumerable<Product> GetProductsStartingWith(string letter);
        IEnumerable<PromoCode> GetProductPromoCodes(int productId);
    }
