    public IQueryable<Person> Search(string column, string value)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var prop = Expression.Property(param, column);
        var val = Expression.Constant(value, prop.Type);
        var equals = Expression.Equal(prop, val);
        var lambda = Expression.Lambda(equals, param);
        return personCollection.Where(lambda);
    }
