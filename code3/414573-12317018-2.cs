    public static FieldInfo[] GetFieldInfosIncludingBaseClasses(Type type, BindingFlags bindingFlags)
    {
        FieldInfo[] fieldInfos = type.GetFields(bindingFlags);
        // If this class doesn't have a base, don't waste any time
        if (type.BaseType == typeof(object))
        {
            return fieldInfos;
        }
        else
        {   // Otherwise, collect all types up to the furthest base class
            var currentType = type;
            var fieldComparer = new FieldInfoComparer();
            var fieldInfoList = new HashSet<FieldInfo>(fieldInfos, fieldComparer);
            while (currentType != typeof(object))
            {
                fieldInfos = currentType.GetFields(bindingFlags);
                fieldInfoList.UnionWith(fieldInfos);
                currentType = currentType.BaseType;
            }
            return fieldInfoList.ToArray();
        }
    }
    private class FieldInfoComparer : IEqualityComparer<FieldInfo>
    {
        public bool Equals(FieldInfo x, FieldInfo y)
        {
            return x.DeclaringType == y.DeclaringType && x.Name == y.Name;
        }
        public int GetHashCode(FieldInfo obj)
        {
            return obj.Name.GetHashCode() ^ obj.DeclaringType.GetHashCode();
        }
    }
