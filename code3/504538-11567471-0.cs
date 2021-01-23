        public static T ParseAttributeValue<T>(this XElement element, string attribute)
        {
            if (typeof(T) == typeof(Int32))
            {
                return (T)(object)Int32.Parse(element.Attribute(attribute).Value);
            }
            if (typeof(T) == typeof(Double))
            {
                return (T)(object)Double.Parse(element.Attribute(attribute).Value);
            }
            if (typeof(T) == typeof(String))
            {
                return (T)(object)element.Attribute(attribute).Value;
            }
            return default(T);
        }
