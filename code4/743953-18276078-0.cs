        public static bool IsNeverValidGenericArgument(this Type type)
        {
            return type.IsNeverValidGenericArgument(true);
        }
        private static bool IsNeverValidGenericArgument(this Type type, bool isRoot)
        {
            var elementType = type.GetElementType();
            if (null != elementType)
            {
                if (type.IsArray)
                    return elementType.IsNeverValidGenericArgument(false);
                return true; // pointer or byref 
            }
            if (isRoot)
            {
                return
                    typeof(void) == type || typeof(RuntimeArgumentHandle) == type
                    ||
                    typeof(ArgIterator) == type || typeof(TypedReference) == type;
            }
            else
            {
                return (typeof(void) == type || typeof(TypedReference) == type);
            }
        }
