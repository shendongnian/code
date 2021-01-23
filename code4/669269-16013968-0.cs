    public static IEnumerable<string> Diff(Type t1, Type t2)
    {
        return t1.GetProperties().Select(p1 => new { Name = p1.Name, Type = p1.PropertyType })
                .Concat(t1.GetFields().Select(f1 => new { Name = f1.Name, Type = f1.FieldType }))
                .Except(t2.GetProperties().Select(p2 => new { Name = p2.Name, Type = p2.PropertyType })
                        .Concat(t2.GetFields().Select(f2 => new { Name = f2.Name, Type = f2.FieldType })))
                .Select(a => a.Name);
    }
