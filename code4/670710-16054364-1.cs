    IQueryable<Work> query = null;  
    query = this.ObjectContext.Works;
    foreach (var param in params)
    {
        query = query.Include(param);
    }
    var result = query.ToList();
