        public static bool IsGenericEnumerable(Type type)
        {
            return type.IsGenericType && 
                type.GetInterfaces().Any(
                ti => (ti == typeof (IEnumerable<>) || ti.Name == "IEnumerable"));
        }
        public static bool IsEnumerable(Type type)
        {
            return IsGenericEnumerable(type) || type.IsArray;
        }
