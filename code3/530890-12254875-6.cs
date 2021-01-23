    public ArrayList ConvertQueryToList(IQueryable query)
    {
        ArrayList results = new ArrayList();
        results.AddRange(query.Cast<object>().ToList());
        return results;
    }
