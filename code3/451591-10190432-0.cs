    interface IProductRepository
    {
        IEnumerable<Product> FindForCategory(int categoryId);
        IEnumerable<Product> FindAllStartingWith(string letter);
    }
    
    interface IPromoCodeRepository
    {
        IEnumerable<PromoCode> FindForProduct(int productId);
    }
