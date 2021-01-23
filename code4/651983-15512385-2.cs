        [Serializable]
        public class SerializableArray
        {
            public int[,] 2DArray = new int[1000,1000];
            public static void Serialize(SerializableArray t)
            {
                Stream stream = File.Open("Test.osl", FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, t);
                stream.Close();
            }
            public static SerializableArray Deserialize()
            {
                Stream stream = File.Open("Test.osl", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                SerializableArray toReturn = (SerializableArray)bformatter.Deserialize(stream);
                stream.Close();
                return toReturn;
            }
        }
