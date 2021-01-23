        /// <summary>
        /// Returns the most common type of two types.
        /// If no common type can be found, null is returned.
        /// </summary>
        static public Type GetCommonBaseClass(Type a, Type b)
        {
            if ((a == null) || (b ==null))
                return null;
            if (a.IsInterface || b.IsInterface)
                return null;
            if (a.IsAssignableFrom(b))
                return a;
            while (true)
            {
                if (b.IsAssignableFrom(a))
                    return b;
                b = b.BaseType;
            }
        }
        /// <summary>
        /// Returns the most common type of one or more types.
        /// If no common type can be found, null is returned.
        /// </summary>
        static public Type GetCommonBaseClass(params Type[] types)
        {
            if ((types == null) || (types.Length == 0))
                return null;
            Type type = types[0];
            for (int i = 0; i < types.Length; i++)
                type = GetCommonBaseClass(type, types[i]);
            return type;
        }
