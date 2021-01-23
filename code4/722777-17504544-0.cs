    public static partial class TypeExtensionMethods
    {
        public static PropertyInfo[] GetPublicProperties(this Type self)
        {
            return self.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where((property) => property.GetIndexParameters().Length == 0 && property.CanRead && property.CanWrite).ToArray();
        }   // eo GetPublicProperties
    }   // eo class TypeExtensionMethods
