    static bool IsMyClass(object obj)
    {
        return obj == null ? false : IsMyClass(obj.GetType());
    }
    static bool IsMyClass(Type type)
    {
        while (type != null)
        {
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(MyClass<>))
            {
                return true;
            }
            type = type.BaseType;
        }
        return false;
    }
