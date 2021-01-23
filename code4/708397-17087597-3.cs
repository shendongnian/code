    public IList<Foo> Search(DbContext<Foo> context, string id1, string id2)
    {
        Func<Foo, bool> predicate = l =>
                (string.IsNullOrEmpty(id1) || l.Id1.Contains(id1))
                && (string.IsNullOrEmpty(id2) || l.Id2.Contains(id2)));
    
        IQueryable<Foo> list = context.Foo.Where(predicate);
    
        if(id1.StartsWith("*") && id1.Length > 1)
        {
            var searchTerm = id1.Substring(1, id1.Length);
            list = list.Where(l => l.EndsWith(searchTerm));
        }
    
        return list.Take(10).ToList(); // Execution occurs at this point
    }
