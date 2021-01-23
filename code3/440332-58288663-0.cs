        public static IEnumerable<(string Name, object Value)> GetProperties(this object src)
        {
            if (src is IDictionary<string, object> dictionary)
            {
                return dictionary.Select(x => (x.Key, x.Value));
            }
            return src.GetObjectProperties().Select(x => (x.Name, x.GetValue(src)));
        }
        public static IEnumerable<PropertyInfo> GetObjectProperties(this object src)
        {
            return src.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !p.GetGetMethod().GetParameters().Any());
        }
