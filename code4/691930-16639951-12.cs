    public List<string> GetValues(Type enumType)
    {
        if(!typeof(Enum).IsAssignableFrom(enumType))
            throw new ArgumentException("enumType should describe enum");
        var names = Enum.GetNames(enumType).Cast<object>();
        var values = Enum.GetValues(enumType).Cast<int>();
        return names.Zip(values, (name, value) => string.Format("Value {0} Name {1}", value, name))
                    .ToList();     
    }
