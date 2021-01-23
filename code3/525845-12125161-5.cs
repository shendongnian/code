    var attrType = typeof(FieldMapAttribute);
    var attr = properties.SelectMany(p => p.GetCustomAttributes(attrType), false)
                         .Cast<FieldMapAttribute>()
                         .FirstOrDefault();
    if (attr != null)
    {
        colName = attr.DbColumnName;
    }
