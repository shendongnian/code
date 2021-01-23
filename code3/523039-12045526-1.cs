    public class Deserializer
    {
        public static T FromJson<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }
    
        public static object FromJson(string json, Type type)
        {
            return new JavaScriptSerializer().Deserialize(json, type);
        }
    }
