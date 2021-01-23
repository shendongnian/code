        public static string dump(Object t)
        {
            Type type = t.GetType();
            if (type.IsGenericType) { // a generic type
                Type[] types2 = type.GetGenericArguments(); // types of the generic parameters
                if (types2.Length == 1) { // just one type...
                    if (t is System.Collections.IEnumerable)
                        return dump(t as System.Collections.IEnumerable); // a collection...iterate
                    else
                        return t.ToString(); // not a collection
                } else {
                    return t.ToString();
                }
            } else { // not a generic
                return t.ToString();
            }
        }
