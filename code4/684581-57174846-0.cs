        public sealed class VersionDeserializer : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                var assemVer1 = Assembly.GetExecutingAssembly().FullName;
                var deserializeType = Type.GetType(string.Format("{0}, {1}", typeName, assemVer1));
                
                return deserializeType;
            }
        }
        private object FromByteArray(byte[] data)
        {
            var bf = new BinaryFormatter
            {
                Binder = new VersionDeserializer()
            };
            using (MemoryStream ms = new MemoryStream(data))
            {
                return bf.Deserialize(ms);
            }
        }
