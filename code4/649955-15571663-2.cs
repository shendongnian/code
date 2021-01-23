    public static XmlAttributeOverrides GetAttributeOverrides(IEnumerable<Type> typesToOverride)
    {
        var overrides = typesToOverride
            .SelectMany(x => x.GetFields())  // Get a flat list of fields from all the types
            .Where(f => f.FieldType == typeof (BaseType))  // Must have the right type
            .Select(f => new
            {
                Field = f,
                Attributes = GetXmlAttributes(f)
            })
            .Where(f => f.Attributes != null)
            .Aggregate(
                new XmlAttributeOverrides(),
                (ov, field) =>
                { 
                    ov.Add(field.Field.DeclaringType, field.Field.Name, field.Attributes); 
                    return ov;
                });
        return overrides;
    }
