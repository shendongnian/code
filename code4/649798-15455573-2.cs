    public static class ShopQueries
    {
        public IQueriable<Product> SelectVegetables(this IQueriable<Product> query)
        {
            return query.Where(x => x.Type == "Vegetable");
        }
        public IQueriable<Product> FreshOnly(this IQueriable<Product> query)
        {
            return query.Where(x => x.PackTime >= DateTime.Now.AddDays(-1));
        }
    }
