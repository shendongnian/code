    public MyGenericConverter(Type type)
    {
        if (type.IsGenericType 
            && type.GetGenericTypeDefinition() == typeof(MyGenericClass<>)
            && type.GetGenericArguments().Length == 1)
        {
            _genericInstanceType = type;
            _innerType = type.GetGenericArguments()[0];
            _innerTypeConverter = TypeDescriptor.GetConverter(_innerType);            
        }
        else
        {
            throw new ArgumentException("Incompatible type", "type");
        }
    }
