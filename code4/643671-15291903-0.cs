    public static class TypeExtension
    {
        public static bool IsCLRType(this Type type)
        {
            var fullname = type.Assembly.FullName;
            return fullname.StartsWith("mscorlib");
        }
    }
