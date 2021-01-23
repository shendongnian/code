    public DALEntity Get(string ID, IEnumerable<string> IncludeEntities = null)
    {
          IQueryable<DALEntity> query = dbSet;
          query = IncludeEntities.Aggregate(query, (current, includePath) => current.Include(includePath));
          query = query.Single(x=>x.Id == ID);
    }
