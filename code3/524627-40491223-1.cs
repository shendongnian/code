    	public static void SerializeAndCompress<T>(T objectToWrite, string filePath) where T : class
        {
            //var buffer = SerializeAndCompress(collection);
            //File.WriteAllBytes(filePath, buffer);
            SerializeAndCompress(objectToWrite, () => new FileStream(filePath, FileMode.Create), null, () =>
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            });
        }
        public static byte[] SerializeAndCompress<T>(T collection) where T : class
        {
            return SerializeAndCompress(collection, () => new MemoryStream(), st => st.ToArray(), null);
        }
