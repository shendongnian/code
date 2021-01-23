    public static object GetDefaultValue(Type type)
    {
        // Non-nullable value types should be boxed, basically
        if (type.IsValueType && !Nullable.GetUnderlyingType(type))
        {
            // Not the swiftest approach in the world, but it works...
            return Activator.CreateInstance(type);
        }
        // Everything else defaults to null
        return null;
    }
