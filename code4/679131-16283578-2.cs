        /// <summary>
        /// Returns the most common type of two types.
        /// If no common type can be found, null is returned.
        /// </summary>
        static public Type GetCommonType(Type a, Type b)
        {
            if ((a == null) || (b ==null))
                return null;
            if (a.IsAssignableFrom(b))
                return a;
            if (b.IsAssignableFrom(a))
                return b;
            if (a.IsInterface || b.IsInterface)
                return null;
            while (true)
            {
                b = b.BaseType;
                if (b.IsAssignableFrom(a))
                    return b;
            }
        }
        /// <summary>
        /// Returns the most common type of one or more types.
        /// If no common type can be found, null is returned.
        /// </summary>
        static public Type GetCommonType(params Type[] types)
        {
            if ((types == null) || (types.Length == 0))
                return null;
            Type type = types[0];
            for (int i = 0; i < types.Length; i++)
                type = GetCommonType(type, types[i]);
            return type;
        }
