    SqlDataReader reader = ...;
    var propertyMappings = typeof (Info).GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Select(p => new {Property = p, Ordinal = reader.GetOrdinal(p.Name)})
        .ToList();
    while (reader.Read())
    {
        var info = new Info();
        foreach (var propertyMapping in propertyMappings)
            propertyMapping.Property.SetValue(info, reader[propertyMapping.Ordinal]);
    }
