    IQueryable<SomeTable> baseQuery = dc.SomeTable;
    IQueryable<SomeTable> query = new List<SomeTable>().AsQueryable();
    foreach (string l in list)
    {
        string s = l;
    
        query.Union(baseQuery.Where(b => b.Value.StartsWith(s + separator) ||
                                 b.Value.EndsWith(separator + s) ||
                                 b.Value.Contains(separator + s + separator) ||
                                 b.Value.Equals(s)));
    }
    if (query.Any()) {/*...*/}
