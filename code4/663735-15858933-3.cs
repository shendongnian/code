        public static string dump(System.Collections.IEnumerable list)
        {
            bool dict = list is System.Collections.IDictionary; // is it a dictionary?
            Type type = null; // Type of the enumerable
            StringBuilder result = new StringBuilder("{");
            foreach (var t in list) {
                if (dict) { // a dictionary
                    if (type == null) type = t.GetType();
                    result.Append(dump(type.GetProperty("Key").GetValue(t,null)));
                    result.Append(" => ");
                    result.Append(dump(type.GetProperty("Value").GetValue(t, null)));
                } else { // a list
                    result.Append(dump(t));
                }
                result.Append(", ");
            }
            result.Append("}");
            return result.ToString();
        }
