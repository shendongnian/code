    public static class XmlSerializerHelper
    {
        public static void Serialize(String path, object @object)
        {
            using (var stream = File.Create(path))
            {
                var s = new XmlSerializer(@object.GetType());
                s.Serialize(stream, @object);
            }
        }
    
        public static T Deserialize<T>(String path)
        {
            using (var stream = File.OpenRead(path))
            {
                var s = new XmlSerializer(typeof(T));
                return (T) s.Deserialize(stream);
            }
        }
    }
