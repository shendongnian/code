    public void BasicSearch(IQueryable<foo> list, string id1, string id2)
    {
        Func<Foo, bool> predicate = l =>
                (string.IsNullOrEmpty(id1) || l.Id1.Contains(id1))
                && (string.IsNullOrEmpty(id2) || l.Id2.Contains(id2)));
        
        list.Where(predicate);
    }
    public void WildcardSearch(IQueryable<Foo> list, string id1)
    {
        if(!id1.StartsWith("*") || id1.Length <= 1) return;
        var searchTerm = id1.Substring(1, id1.Length);
        list.Where(l => l.EndsWith(searchTerm));
    }
    IQueryable<Foo> list = context.Foo;
    BasicSearch(list, id1, id2);
    WildcardSearch(list, id1);
    var result = list.Take(10); // Execution occurs at this point
