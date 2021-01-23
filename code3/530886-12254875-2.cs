    public ArrayList ConvertQueryToList(IQueryable query)
    {
        ArrayList results = new ArrayList();
        results.AddRange(query);
        return results;
    }
