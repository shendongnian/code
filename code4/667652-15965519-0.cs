    public IQueryable<MyTable> GetRows(int from, int to)
    {
       var queryRes = SomeDataContext.MyTable.OrderBy(r => r.Id);
       return queryRes.Take(to).Skip(from);
    }
