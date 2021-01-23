     public static T Map<T>(Dictionary<string, string> dictionary) where T : class, new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();
    
            foreach (var item in dictionary)
            {
                var prop = properties.FirstOrDefault(p => p.Name.Equals(item.Key, StringComparison.InvariantCultureIgnoreCase));
                if (prop != null)
                    prop.SetValue(obj, item.Value, null);
            }
    
            return obj;
        }
...
     var dictionary = new Dictionary<string, string> { { "name", "Smith" }, { "age", "20" } };
     Person o = Map<Person>(dictionary);
