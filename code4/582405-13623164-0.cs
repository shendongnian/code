     public static T GetXmlValue<T>(this XmlNode node, string name, T defaultValue)
        {
            if (node != null && node[name] != null)
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)node[name].InnerText;
                }
                else if (typeof(T) == typeof(int))
                {
                    int value = 0;
                    if (int.TryParse(node[name].InnerText, out value))
                    {
                        return (T)(object)value;
                    }
                }
            }
            return defaultValue;
        }
