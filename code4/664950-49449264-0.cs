    using System.IO;
    using System.Runtime.Serialization.Json;
    
    ...
    
    private T Deserialize<T>(string json) where T : class
    {
        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            return ser.ReadObject(ms) as T;
        }
    }
            
