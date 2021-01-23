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
                var value = pi.GetValue(obj, null);            
                if (pi.PropertyType.IsPrimitive ||
                    pi.PropertyType == typeof(string))
                {
                    writer.WriteElementString(pi.Name, 
                                       (value == null) ? "" : value.ToString());
                    continue;
                }
                if (value == null)
                    continue;
                Extensions.ToXml((dynamic)value, writer);
            }
            
            writer.WriteEndElement();
            writer.WriteEndElement();
        }   
    }
