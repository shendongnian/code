     public static T BinaryDeserializeObject<T>(byte[] serializedType)
        {
            if (serializedType == null)
                throw new ArgumentNullException("serializedType");
            if (serializedType.Length.Equals(0))
                throw new ArgumentException("byte array cannot be empty"));
            T deserializedObject;
            using (MemoryStream memoryStream = new MemoryStream(serializedType))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                deserializedObject = (T)deserializer.Deserialize(memoryStream);
            }
            return deserializedObject;
        }
