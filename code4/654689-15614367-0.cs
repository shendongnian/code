    public static class Serialization
    {
        public static string Serialize<T>(T obj)
        {
            //Create a stream to serialize the object to.
            var ms = new MemoryStream();
            // Serializer the User object to the stream.
            var ser = new DataContractSerializer(typeof (T));
            ser.WriteObject(ms, obj);
            byte[] array = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(array, 0, array.Length);
        }
        public static T Deserialize<T>(string obj) where T : class
        {
            if (obj == null)
                return null;
            var serializer = new DataContractSerializer(typeof (T));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(obj));
            var result = serializer.ReadObject(stream) as T;
            return result;
        }
    }
