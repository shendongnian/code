        public static byte[] Serialize<T>(T obj)
        {
            var serializer = new DataContractSerializer(typeof(T), MyGlobalObject.ResolveKnownTypes());
            var stream = new MemoryStream();
            using (var writer =
                XmlDictionaryWriter.CreateBinaryWriter(stream))
            {
                serializer.WriteObject(writer, obj);
            }
            return stream.ToArray();
        }
        public static T Deserialize<T>(byte[] data)
        {
            var serializer = new DataContractSerializer(typeof(T), MyGlobalObject.ResolveKnownTypes());
            using (var stream = new MemoryStream(data))
            using (var reader =
                XmlDictionaryReader.CreateBinaryReader(
                    stream, XmlDictionaryReaderQuotas.Max))
            {
                return (T)serializer.ReadObject(reader);
            }
        }
