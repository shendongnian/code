    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    public static T Deserialize<T>(string json)
    {
        var _Bytes = Encoding.Unicode.GetBytes(json);
        using (MemoryStream _Stream = new MemoryStream(_Bytes))
        {
            var _Serializer = new DataContractJsonSerializer(typeof(T));
            return (T)_Serializer.ReadObject(_Stream);
        }
    }
    public static string Serialize(object instance)
    {
        using (MemoryStream _Stream = new MemoryStream())
        {
            var _Serializer = new DataContractJsonSerializer(instance.GetType());
            _Serializer.WriteObject(_Stream, instance);
            _Stream.Position = 0;
            using (StreamReader _Reader = new StreamReader(_Stream)) 
            { return _Reader.ReadToEnd(); }
        }
    }
