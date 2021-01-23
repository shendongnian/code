    // You can add any paramaters you want to this method
    // You can also turn this into an extension method
    public Func<IQueryable<TItem>, IQueryable<TItem>> MyQuery()
    {
       return (IQueryable<TItem> items) => (items.Select...);
    }
