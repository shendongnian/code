    public static bool IsDefined(this Type t, Type attrType)
    {
        if (t == null) {
            return false;
        }
        return 
            t.GetCustomAttributes(attrType, true).Length > 0 ||
            t.BaseType.IsDefined(attrType);
    }
