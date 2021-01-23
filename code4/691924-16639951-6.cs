    public List<string> GetValues(Type enumType)
    {
        if(typeof(Enum).IsAssignableFrom(enumType))
        {
    		Array names = Enum.GetNames(enumType);
            Array values = Enum.GetValues(enumType);
    		          
            return names.Cast<object>()
    		            .Zip(values.Cast<object>(), 
    						(name, value) => string.Format("Value {0} Name {1}", (int)value, name))
                        .ToList();
        }
        throw new ArgumentException("enumType should describe enum");
    }
