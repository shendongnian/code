    public static class Extensions
    {
        public static XElement ToXml<T>(this T obj)
        {
            Type type = typeof(T);
    
            return new XElement("Class",
                        new XElement(type.Name,
                            from pi in type.GetProperties()
                            where !pi.GetIndexParameters().Any()
                            let value = (dynamic)pi.GetValue(obj, null)
                            select pi.PropertyType.IsPrimitive || 
                                   pi.PropertyType == typeof(string) ?
                                    new XElement(pi.Name, value) : 
                                    Extensions.ToXml(value)
                            )
                        );
        }
    }
