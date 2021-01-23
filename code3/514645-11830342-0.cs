    public static class TypeExtensions {
        public static bool InterfaceInheritsFrom(this Type sourceType, Type targetType) {
            if (!sourceType.IsInterface || !targetType.IsInterface) return false;
            return sourceType.GetInterfaces().Any(I => I.GUID == targetType.GUID);
        }
    }
