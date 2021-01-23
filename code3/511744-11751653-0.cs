    var patterns = new List<string>();
    using (var context = new MyDataContext())
    {
        var query = (IQueryable<Area>)context.Areas;
        foreach (var pattern in patterns)
        {
            query = query.Where(a => a.Description.Contains(pattern));
        }
        return query.ToList();
    }
