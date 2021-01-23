        public class JsonHelper
    {
        public static string JsonSerializer<T>(object obj)
        {
            try
            {
                if (obj == null)
                    return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                    serializer.WriteObject(ms, obj);
                    ms.Position = 0;
                    using (StreamReader reader = new StreamReader(ms))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch { return null; }
        }
        public static T JsonDeserialize<T>(string source)
        {
            try
            {
                if (source == null)
                    return default(T);
                using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(source)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    if (ms.Length == 0)
                        return default(T);
                    return (T)serializer.ReadObject(ms);
                }
            }
            catch { return default(T); }
        }
    }
