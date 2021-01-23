        public static bool IsConcreteGenericOf(this Type type, Type openGeneric)
        {
            if (!type.IsGenericType)
                return false;
            if (!openGeneric.IsGenericType)
                return false;
            if (!openGeneric.IsGenericTypeDefinition)
                return false;
            return type.GetGenericTypeDefinition() == openGeneric;
        }
