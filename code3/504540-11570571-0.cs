    using System.ComponentModel;
    public static T ParseAttributeValue<T>(this XElement element, string attribute)
    {
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter.CanConvertFrom(typeof(string)))
        {
            string value = element.Attribute(attribute).Value;
            return (T)converter.ConvertFromString(value);
        }
        return default(T);
    }
