    public static class Extensions
    {
        public static void ToXml<T>(this T obj, XmlWriter writer)
        {
            Type type = typeof(T);
            writer.WriteStartElement("Class");
            writer.WriteStartElement(type.Name);
    
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (pi.GetIndexParameters().Length > 0)
                    continue;
    
                var value = (dynamic)pi.GetValue(obj, null);
                if (value == null)
                    continue;
    
                if (pi.PropertyType.IsPrimitive ||
                    pi.PropertyType == typeof(string))
                {
                    writer.WriteElementString(pi.Name, value.ToString());
                    continue;
                }
    
                Extensions.ToXml(value, writer);
            }
                
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
