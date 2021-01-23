    public DALEntity Get(string ID, IEnumerable<string> IncludeEntities = null)
    {
      var set = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<DALEntity>();
      var entitySet = set.EntitySet;
      string[] keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
      Debug.Assert(keyNames.Length == 1, "DAL does not work with composite primary keys or tables without primary keys");
      IQueryable<DALEntity> query = dbSet;
      query = IncludeEntities.Aggregate(query, (current, includePath) => current.Include(includePath));
      query = query.Where(keyNames[0] + "= @0", ID);
      return query.FirstOrDefault();
    }
