    public static BasedOnDescriptor WithServiceLastAbstractBase(this BasedOnDescriptor basedOn)
    {
        return basedOn.WithServiceSelect(selectLastAbstractBase);
    }
    private static IEnumerable<Type> selectLastAbstractBase(Type type, Type[] basetypes)
    {
        var baseType = type;
        do
        {
            baseType = baseType.BaseType;
        } while (baseType != null && !baseType.IsAbstract);
        if (baseType == null)
        {
            throw new ArgumentException("There are no abstract base types for: " + type);
        }
        return new [] { baseType };
    }
