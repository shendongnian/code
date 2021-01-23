    public static class ShopQueries
    {
        public IQueryable<Product> SelectVegetables(this IQueryable<Product> query)
        {
            return query.Where(x => x.Type == "Vegetable");
        }
        public IQueryable<Product> FreshOnly(this IQueryable<Product> query)
        {
            return query.Where(x => x.PackTime >= DateTime.Now.AddDays(-1));
        }
    }
