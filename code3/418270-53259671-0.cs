        public static string ToString(object serializeable)
        {
            var type = serializeable.GetType();
            try
            {
                var sw = new StringWriter();
                new XmlSerializer(type).Serialize(sw, serializeable);
                return sw.ToString();
            }
            catch
            {
                return type.FullName;
            }
        }
