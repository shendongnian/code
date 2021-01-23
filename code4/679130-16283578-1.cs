        static public Type GetCommonType(Type a, Type b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a.IsAssignableFrom(b))
                return a;
            while (true)
            {
                if (b.IsAssignableFrom(a))
                    return b;
                b = b.BaseType;
            }
        }
