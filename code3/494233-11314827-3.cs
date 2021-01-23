    public Item GetItem(Func<IQueryable<TItem>, IQueryable<TItem>> query)
    {
        using (var context = new MyContext())
        {
            return query(context.Items).SingleOrDefault();
        }
    }
