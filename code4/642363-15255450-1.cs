    public static class XmlSerializerHelper
    {
        public static T DeSerializeStringToObject<T>(this string sxml)
        {
            using (XmlTextReader xreader = new XmlTextReader(new StringReader(sxml.Replace("&", "&amp;"))))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(xreader);
            }
        }
    
        public static string SerializeObjectToString(this object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer x = new XmlSerializer(obj.GetType());
                x.Serialize(stream, obj);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }
    }
