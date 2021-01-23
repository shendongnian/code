    public static string SerializeObject<T>(this T source, bool serializeNonPublic = false)
    {
        if (source == null)
        {
            return null;
        }
    
        var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
    
        if (serializeNonPublic)
        {
            bindingFlags |= BindingFlags.NonPublic;
        }
    
        var properties = typeof(T).GetProperties(bindingFlags).Where(property => property.CanRead).ToList();
        var sb = new StringBuilder();
    
        using (var writer = XmlWriter.Create(sb))
        {
            writer.WriteStartElement(typeof(T).Name);
            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(source, null);
    
                    writer.WriteStartElement(property.Name);
                    writer.WriteAttributeString("Type", property.PropertyType.Name);
                    writer.WriteAttributeString("Value", value.ToString());
                    writer.WriteEndElement();
                }
            }
            else if (typeof(T).IsValueType)
            {
                writer.WriteValue(source.ToString());
            }
    
            writer.WriteEndElement();
        }
    
        return sb.ToString();
    }
