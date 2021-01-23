    ublic static class Ext
    {
        public static IList<KeyValuePair<string, int>> AsOrderColumns(this Test item)
        {
            var type = item.GetType();
            return type.GetProperties()
                       .Where(w => w.IsOrderColumn())
                       .Select(s => s.GetOrderColumn())
                       .OrderBy(o => o.Value)
                       .ToList();
        }
        private static bool IsOrderColumn(this PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(DataMemberAttribute), true).Any();
        }
        private static KeyValuePair<string, int> GetOrderColumn(this PropertyInfo property)
        {
            var attr = property.GetCustomAttributes(typeof(DataMemberAttribute), true).ElementAt(0) as DataMemberAttribute;
            return (attr != null)
                ? new KeyValuePair<string, int>(attr.Name, attr.Order)
                : new KeyValuePair<string, int>();
        }
         
        public static IList<string> AsOrderRow(this Test item)
        {
            var type = item.GetType();
            var props = type.GetProperties();
            return props.Select(s => s.GetValue(item,null).ToString()).ToList();
        }
    }
