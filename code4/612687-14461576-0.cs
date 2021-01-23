    using (TestModelContainer context = new TestModelContainer())
    {
        var query = (from t in context.Tests select t);
        return query.ToList();
    }
