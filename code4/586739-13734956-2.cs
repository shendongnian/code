    public Container Find(Expression<Func<Data, bool>> predicate ) 
    {
        return MyDbContext.Containers
                          .Join(MyDbContext.Containers.Select(c => c.Data)
                                                      .Where(predicate), 
                                c => c.Data.Id,
                                d => d.Id,
                                (c, d) => c)
                          .FirstOrDefault();
    }
