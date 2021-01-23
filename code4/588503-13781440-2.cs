       public static void SerializeToStream<T>(Stream stream, object model)
       {
            var writer = XmlWriter.Create(stream);
            var s = new XmlSerializer(typeof(T));
            s.Serialize(writer, model);
        }
        public static string SerializeToString<T>(object model)
        {
            var xmlSer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                SerializeToStream<T>(stream, model);
                var s = stream.ToArray();
                return System.Text.Encoding.UTF8.GetString(s, 0, s.Length);
            }
        }
        public static void SerializeToFile<T>(string filename, object model)
        {
            using (FileStream stream = File.Open(filename, FileMode.Create))
            {
                SerializeToStream<T>(stream, model);
            }
        }
