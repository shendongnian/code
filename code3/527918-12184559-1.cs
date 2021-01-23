        public static string Serialize(FormulaStructure structure)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                var serializer = new DataContractSerializer(typeof(FormulaStructure));
                serializer.WriteObject(memoryStream, structure);
                memoryStream.Position = 0;
                return reader.ReadToEnd();
            }
        }
        public static FormulaStructure Deserialize(string xml)
        {
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(typeof(FormulaStructure));
                return (FormulaStructure)deserializer.ReadObject(stream);
            }
        }
