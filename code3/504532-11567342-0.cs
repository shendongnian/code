    public static Object ParseAttributeValue<T>(this XElement element, string attribute)
    {
        if(typeof(T) == typeof(Int32))
        {
            return Int32.Parse(element.Attribute(attribute).Value);
        }
        if(typeof(T) == typeof(Double))
        {
            return Double.Parse(element.Attribute(attribute).Value);
        }
        if(typeof(T) == typeof(String))
        {
            return element.Attribute(attribute).Value;
        }
        if(typeof(T) == typeof(ItemLookupType))
        {
            return Enum.Parse(typeof(T), element.Attribute(attribute).Value);
        }
    }
