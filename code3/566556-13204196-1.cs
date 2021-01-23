    var xml = movie.SerializeToXML();
    public static class SOExtensions
    {
        public static string SerializeToXML<T>(this T obj)  where T : new()
        {
            StringWriter s = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(s, obj);
            return s.ToString();
        }
    }
