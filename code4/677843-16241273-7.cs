     public static class Ext
        {
    
            public static IList<KeyValuePair<string, int>> AsOrderColumns<T>(this T t)
                where T : class
            {
                return t.GetType()
                        .GetProperties()
                        .Where(w => w.IsOrderColumn())
                        .Select(s => s.GetOrderColumn())
                        .OrderBy(o => o.Value)
                        .ToList();
    
            }
    
            private static bool IsOrderColumn(this PropertyInfo prop)
            {
                return prop.GetCustomAttributes(typeof(DataMemberAttribute), true)
                           .Any();
            }
    
            private static KeyValuePair<string, int> GetOrderColumn(this PropertyInfo prop)
            {
                var attr = prop.GetCustomAttributes(typeof(DataMemberAttribute), true)
                               .ElementAt(0) as DataMemberAttribute;
    
                return (attr != null)
                    ? new KeyValuePair<string, int>(attr.Name, attr.Order)
                    : new KeyValuePair<string, int>();
            }
    
            public static IList<object> AsOrderRow<T>(this T t)
                where T : class
            {
                return t.GetType()
                        .GetProperties()
                        .Where(w => w.IsOrderColumn())
                        .OrderBy(o => o.GetOrderColumn().Value)
                        .Select(s => s.GetValue(t, null))
                        .ToList();
            }
    
        }
