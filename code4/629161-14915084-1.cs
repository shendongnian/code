     class Program
    {
        [Serializable]
        public class Search
        {
            public Guid ID { get; private set; }
            public Search() { }
            public Search(Guid id)
            {
                ID = id;
            }
            public override string ToString()
            {
                return ID.ToString();
            }
        }
        static void Main(string[] args)
        {
            Search search = new Search(Guid.NewGuid());
            Console.WriteLine(search);
            string serialized = SerializeTest.SerializeToString(search);
            Search rehydrated = SerializeTest.DeSerializeFromString<Search>(serialized);
            Console.WriteLine(rehydrated);
            Console.ReadLine();
        }
    }
    public class SerializeTest
    {
        public static Encoding _Encoding = Encoding.Unicode;
        public static string SerializeToString(object obj)
        {
            byte[] byteArray = BinarySerializeObject(obj);
            return Convert.ToBase64String(byteArray);
        }
        public static T DeSerializeFromString<T>(string input)
        {
            byte[] byteArray = Convert.FromBase64String(input);
            return BinaryDeserializeObject<T>(byteArray);
        }
        /// <summary>
        /// Takes a byte array and deserializes it back to its type of <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">The Type to deserialize to</typeparam>
        /// <param name="serializedType">The object as a byte array</param>
        /// <returns>The deserialized type</returns>
        public static T BinaryDeserializeObject<T>(byte[] serializedType)
        {
            if (serializedType == null)
                throw new ArgumentNullException("serializedType");
            if (serializedType.Length.Equals(0))
                throw new ArgumentException("serializedType");
            T deserializedObject;
            using (MemoryStream memoryStream = new MemoryStream(serializedType))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                deserializedObject = (T)deserializer.Deserialize(memoryStream);
            }
            return deserializedObject;
        }
        /// <summary>
        /// Takes an object and serializes it into a byte array
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize</param>
        /// <returns>The object as a <see cref="byte"/> array</returns>
        public static byte[] BinarySerializeObject(object objectToSerialize)
        {
            if (objectToSerialize == null)
                throw new ArgumentNullException("objectToSerialize");
            byte[] serializedObject;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSerialize);
                serializedObject = stream.ToArray();
            }
            return serializedObject;
        }
    }
