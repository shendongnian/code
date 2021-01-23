            let info = GetInfo(property)
            select new {
                TypeName = type.Name,
                PropertyName = info.Item1,
                PropertyType = property.PropertyType.Name,
                IsNullable = info.Item2
            };
    ....
    private Tuple<string,bool> GetInfo(PropertyInfo property)
    {
        string typeName;
        bool isNullable = false;
        ...
        return Tuple.Create(typeName, isNullable);
    }
