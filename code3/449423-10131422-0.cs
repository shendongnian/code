    public static class ExtensionMethods
    {
        public static PropertyInfo[] GetNonPublicProperties(this Type t) {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Where(prop => prop.GetAccessors(true).Where(mi => mi.IsPublic == false).Count() != 0).ToArray();
        }
    }
