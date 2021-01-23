    public static string[] Foo<T>(Expression<Func<T, object>> func)
    {
        var properties = func.Body.Type.GetProperties();
        return typeof(T).GetProperties()
            .Where(p => properties.Any(x => p.Name == x.Name))
            .Select(p =>
            {
                var attr = (ColumnAttribute) p.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault();
                return (attr != null ? attr.Name : p.Name);
            }).ToArray();
    }
