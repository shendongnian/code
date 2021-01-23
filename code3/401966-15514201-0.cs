    /// <summary>
    /// Extension method to check the entire inheritance hierarchy of a
    /// type to see whether the given base type is inherited.
    /// </summary>
    /// <param name="t">The Type object this method was called on</param>
    /// <param name="baseType">The base type to look for in the 
    /// inheritance hierarchy</param>
    /// <returns>True if baseType is found somewhere in the inheritance 
    /// hierarchy, false if not</returns>
    public static bool InheritsFrom(this Type t, Type baseType)
    {
        Type cur = t.BaseType;
        while (cur != null)
        {
            if (cur.Equals(baseType))
            {
                return true;
            }
            cur = cur.BaseType;
        }
        return false;
    }
