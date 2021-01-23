    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace YourApp.Helpers
    {
        public class SystemSerializer:ISerializer
        {
            public T Deserialize<T>(string json) where T : class
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
    
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    return ser.ReadObject(ms) as T;
                }
            }
    
            public T Deserialize<T>(Stream json) where T : class
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                return ser.ReadObject(json) as T;
            }
    
            public async Task<string> SerializeAsync<T>(T obj) where T : class
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                using (var ms = new MemoryStream())
                {
                    ser.WriteObject(ms, obj);
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                    {
                        return await sr.ReadToEndAsync();
                    }
                }
            }
        }
    }
