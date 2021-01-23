        static public Type GetCommonType(Type a, Type b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a == b)
                return a;
            if (a.IsSubclassOf(b))
                return b;
            if (b.IsSubclassOf(a))
                return a;
            while (true)
            {
                a = a.BaseType;
                if (a == null)
                    return null;
                if (b.IsSubclassOf(a))
                    return a;
            }
        }
