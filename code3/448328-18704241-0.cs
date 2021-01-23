    public IEnumerable<Address> Search(string query, int maxCount)
    {
        return session.CreateSQLQuery("SELECT * FROM address WHERE fts_col @@ plainto_tsquery('cs', :query) LIMIT :limit;")
            .AddEntity(typeof(Address)) // this is probably what you need to map to entity
            .SetString("query", query)
            .SetInt32("limit", maxCount)
            .List<Address>();
    }
