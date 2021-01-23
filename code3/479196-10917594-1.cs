    public class JSONHelper
    {
        public static T Deserialise<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(obj.GetType());
            ms.Close();
            return obj;
        }
    }
