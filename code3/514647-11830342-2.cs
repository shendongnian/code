    public static class TypeExtensions {
        public static bool OpenIsAssignableFrom(this Type baseType, Type c, bool strongName = true) {
            if (!baseType.IsGenericTypeDefinition || !c.IsGenericTypeDefinition) return false;
            if (baseType.IsInterface)
                return c.ImplementsOpenInterface(baseType);
            Type testBaseType = c;
            while (testBaseType != null) {
                if (baseType.GetFullName(strongName) == testBaseType.GetFullName(strongName)) return true;
                testBaseType = testBaseType.BaseType;
            }
            return false;
        }
        public static bool ImplementsOpenInterface(this Type sourceType, Type ifaceType, bool strongName = true) {
            if (!ifaceType.IsInterface) return false;
            return sourceType.GetInterfaces().Any(I => I.GetFullName(strongName) == ifaceType.GetFullName(strongName));
        }
        public static string GetFullName(this Type type, bool strongName = false) {
            string name = type.FullName ?? "";
            if (name.Length == 0)
                name = type.Namespace + "." + type.Name;
            if (strongName)
                name += ", " + type.Assembly.FullName;
            return name;
        }
    }
