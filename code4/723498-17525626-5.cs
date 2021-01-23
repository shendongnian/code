        public static string SerializeObject<T>(this T obj)
        {
            var ms = new MemoryStream();
            var xs = new XmlSerializer(obj.GetType());
            var xmlTextWriter = new XmlTextWriter(ms, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, obj);
            string serializedObject = new UTF8Encoding().GetString((((MemoryStream)xmlTextWriter.BaseStream).ToArray()));
            return serializedObject;
        }
