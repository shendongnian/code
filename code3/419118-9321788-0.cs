    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Data d = new Data { CurrentDateTime = DateTime.Now, DataId = 1 };
                Data d1 = new Data { CurrentDateTime = DateTime.Now, DataId = 2 };
                Data d2 = new Data { CurrentDateTime = DateTime.Now, DataId = 3 };
    
                CustomCollection cc = new CustomCollection
                                          {List = new List<Data> {d, d1, d2}};
                
                //This is the xml
                string xml = MessageSerializer<CustomCollection>.Serialize(cc);
    
                //This is deserialising it back to the original collection
                CustomCollection collection = MessageSerializer<CustomCollection>.Deserialize(xml);
            }
        }
    
        [Serializable]
        public class Data
        {
            public int DataId;
            public DateTime CurrentDateTime;
            public DateTime? CurrentNullableDateTime;
        }
    
        [Serializable]
        public class CustomCollection
        {
            public List<Data> List;
        }
    
        public class MessageSerializer<T>
        {
            public static T Deserialize(string type)
            {
                var serializer = new XmlSerializer(typeof(T));
    
                var result = (T)serializer.Deserialize(new StringReader(type));
    
                return result;
            }
    
            public static string Serialize(T type)
            {
                var serializer = new XmlSerializer(typeof(T));
                string originalMessage;
    
                using (var ms = new MemoryStream())
                {
                    serializer.Serialize(ms, type);
                    ms.Position = 0;
                    var document = new XmlDocument();
                    document.Load(ms);
    
                    originalMessage = document.OuterXml;
                }
    
                return originalMessage;
            }
        }
    }
