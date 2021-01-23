    Dictionary<Type, TypeConverter> _ConverterCache = new Dictionary<Type, TypeConverter>();
    TypeConverter GetCachedTypeConverter(Type type)
    {
        if (!_ConverterCache.ContainsKey(type))
            _ConverterCache.Add(type, TypeDescriptor.GetConverter(type));
         return _ConverterCache[type];
    }
