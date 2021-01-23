    static class XmlNodeExtensions {
        public static T GetAttrValue(this XmlNode node, string attrName) {
            return GetAttrValue(node, attrName, default(T));
        }
        public static T GetAttrValue(this XmlNode node, string attrName, T defaultValue) {
            var attr = node.Attributes.GetNamedItem(attrName);
            if (attr != null) {
                var value = attr.Value; 
                var tT = typeof(T);       // target Type
                if (tT.IsAssignableFrom(typeof(string)))
                {
                    return (T)value;
                } else
                {
                    var converter = TypeDescriptor.GetConverter(tT);
                    if (converter.CanConvertFrom(typeof(string)))
                    {
                        return (T)converter.ConvertFrom(value);
                    } else
                    {
                        throw new InvalidOperationException("No conversion possible");
                    }
                }
            } else {
                return defaultValue;
            }
        }
    }
