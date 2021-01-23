    public IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            //Just to avoid the string
            if (type == typeof(String)) return new PropertyInfo[] { };
            var properties = type.GetProperties().ToList();
            foreach (var p in properties.ToList())
            {
                if (p.PropertyType.IsClass)
                    properties.AddRange(GetProperties(p.PropertyType));
                else if (p.PropertyType.IsGenericType)
                {
                    foreach (var g in p.PropertyType.GetGenericArguments())
                    {
                        if (g.IsClass)
                            properties.AddRange(GetProperties(g));
                    }
                }
            }
            return properties;
            
        }
