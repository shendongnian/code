    var properties = item.GetType().GetProperties()
        .Where(p => p.GetCustomAttributes(true).Any())
        .Select (x => new 
        {
            Property = x,
            Attribute = Attribute.GetCustomAttribute(x, typeof(IsInPkAttribute), true) ?? Attribute.GetCustomAttribute(x, typeof(IncludeInEditorAttribute, true))
        })
        .OrderBy(x => x.Attribute, new AttributeComparer())
        .Select(x => x.Property)
        .ToArray();
