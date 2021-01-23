    public static T Deserialize<T>(this  XmlReader xml)
        {
            if (xml == null)
            {
                return default(T);
            }
            var serializer = new XmlSerializer(typeof(T));
            var settings = new XmlReaderSettings();
            // No settings need modifying here
           
            return (T)serializer.Deserialize(xml);
        }
