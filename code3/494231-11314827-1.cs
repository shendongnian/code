    public Item GetItem(Func<IQueryable, IQueryable> query)
    {
        using (var context = new MyContext())
        {
            return query(context.Items).SingleOrDefault();
        }
    }
