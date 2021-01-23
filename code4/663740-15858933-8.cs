    public static string dump(Object o)
    {
        Type type = o.GetType();
        // if it's a generic, check if it's a collection or keyvaluepair
        if (type.IsGenericType) {
            // a collection? iterate items
            if (o is System.Collections.IEnumerable) {
                StringBuilder result = new StringBuilder("{");
                foreach (var i in (o as System.Collections.IEnumerable)) {
                    result.Append(dump(i));
                    result.Append(", ");
                }
                result.Append("}");
                return result.ToString();
            // a keyvaluepair? show key => value
            } else if (type.GetGenericArguments().Length == 2 &&
                       type.FullName.StartsWith("System.Collections.Generic.KeyValuePair")) {
                StringBuilder result = new StringBuilder();
                result.Append(dump(type.GetProperty("Key").GetValue(o, null)));
                result.Append(" => ");
                result.Append(dump(type.GetProperty("Value").GetValue(o, null)));
                return result.ToString();
            }
        }
        // arbitrary generic or not generic
        return o.ToString();
    }
