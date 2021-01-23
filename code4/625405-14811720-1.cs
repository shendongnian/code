    public GenericRepository(DbContext context)
    {
        _context = (context as IObjectContextAdapter).ObjectContext;
        _objectSet = _context.CreateObjectSet<TEntity>();
    }
