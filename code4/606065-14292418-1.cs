    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable()]
    public class MyData
    {
         private string[,,] SArr;
    
         public MyData(int sizex,int sizey,int sizez)
         {
            SArr = new string[sizex,sizey,sizez];
         }         
         public MyData(string[,,] data)
         {
            SArr = data;
         }         
         public string this[x,y,z]
         {
            get
            {
                return SArr[x,y,z];
            }
            set
            {
                SArr[x,y,z] = value;
            }
         }
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
