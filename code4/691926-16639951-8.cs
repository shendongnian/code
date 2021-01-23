    public List<string> GetValues(Type enumType)
    {
        if(typeof(Enum).IsAssignableFrom(enumType))
        {
            var names = Enum.GetNames(enumType).Cast<object>();
            var values = Enum.GetValues(enumType).Cast<object>();
    
            return names.Zip(values, (name, value) => string.Format("Value {0} Name {1}", (int)value, name))
                        .ToList();
        }
        throw new ArgumentException("enumType should describe enum");
    }
