    public static class QueryOverExtensions
    {
        public static Order LastOrder(this IQueryOver<Order, Order> query)
        {
            return query
                .OrderBy(sr => sr.CompleteUtcTime).Desc
                .Take(1)
                .SingleOrDefault<Order>();
        }
        
        // Other query over extension methods
    }
