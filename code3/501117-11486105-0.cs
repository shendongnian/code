    static public class SerialHelperExtensions
    {
        static public void Serialize<T>(this T obj, string path)
        {
            SerializationHelper.Serialize<T>(obj, path);
        }
    }
    static public class SerializationHelper
    {
        static public void Serialize<T>(T obj, string path)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(T));
            using (FileStream fs = File.Open(path, FileMode.Create))
            {
                s.WriteObject(fs, obj);
            }
        }
        static public T Deserialize<T>(string path)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(T));
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                object s2 = s.ReadObject(fs);
                return (T)s2;
            }
        }
    }
