    public static Type FindEqualTypeWith(this Type type1, Type type2)
    {
        if(type1 == type2) 
            return type1;
        var baseClass = type1.FindBaseClassWith(type2);
        if(baseClass == typeof(object))
        {
            var @interface = type1.FindInterfaceWith(type2);
            if(@interface != null)
                return @interface;
        }
        return baseClass;
