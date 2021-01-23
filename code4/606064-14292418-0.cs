    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable()]
    public class MyData
    {
         string[,,] SArr = new string[4,4,4];
    
         public void SaveToFile(String fileName)
         {
              Stream TestFileStream = File.Create(fileName);
              BinaryFormatter serializer = new BinaryFormatter();
              serializer.Serialize(TestFileStream, this);
              TestFileStream.Close();
         }
        public static MyData ReadFromFile(String fileName)
        {
            if (File.Exists(FileName))
            {
                Stream TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                var data = (MyData)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
                return data;
            }
            return null;
        }
    }
