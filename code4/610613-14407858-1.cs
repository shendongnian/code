        public static void SaveAsXML(this Object A, string FileName)
        {
            var serializer = new XmlSerializer(A.GetType());
            using (var textWriter = new StreamWriter(FileName))
            {
                serializer.Serialize(textWriter, A);
                textWriter.Close();
            }
        }
        public static void LoadFromXML(this Object A, string FileName)
        {
            if (File.Exists(FileName))
            {
                using (TextReader textReader = new StreamReader(FileName))
                {
                    XmlSerializer deserializer = new XmlSerializer(A.GetType());
                    A = (deserializer.Deserialize(textReader));
                }
            }
        }
